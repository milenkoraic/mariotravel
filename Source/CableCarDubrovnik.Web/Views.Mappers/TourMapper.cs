using CableCarDubrovnik.Web.App.Infrastructure.TextModification;
using CableCarDubrovnik.Web.App.Localization.Mapping;
using CableCarDubrovnik.Web.Models;
using CableCarDubrovnik.Web.Models.Models;
using CableCarDubrovnik.Web.Models.Tour;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Payment;
using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.Configuration.Images;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CableCarDubrovnik.Web.Views.Mappers
{
    public class TourMapper
    {
        private readonly IStringLocalizer<MappingResources> mappingLocalization;
        private readonly ImageDirectory imageDirectory;
        private readonly PaymentOptions PaymentOptions;

        public TourMapper(
            IOptions<PaymentOptions> paymentOptionsAccessor,
            IOptions<ImageDirectory> imageDirectoryAccessor,
            IStringLocalizer<MappingResources> mappingLocalizationAccessor)
        {
            this.mappingLocalization = EnsureArg.IsNotNull(mappingLocalizationAccessor);
            EnsureArg.IsNotNull(imageDirectoryAccessor, nameof(imageDirectoryAccessor));
            imageDirectory = imageDirectoryAccessor.Value;
            EnsureArg.IsNotNull(paymentOptionsAccessor, nameof(paymentOptionsAccessor));
            PaymentOptions = paymentOptionsAccessor.Value;
        }

        public TourPreviewViewModel ToPreviewViewModel(TourPreview tour)
        {
            var mainImageVm = TourImageViewModel(tour.MainImage);
            var displayPrice = GenerateDisplayPrice(tour);
            var displayChildPrice = GenerateDisplayChildPrice(tour);
            var displayDepartureTimes = GenerateDisplayDepartureTimes(tour.TourTimes);
            var displayDuration = GenerateDisplayDuration(tour);
            var discountPercent = GenerateDiscountPercent(tour);

            return new TourPreviewViewModel(
                tour.Id, 
                tour.Title, 
                tour.Description, 
                displayPrice, 
                displayChildPrice, 
                displayDepartureTimes, 
                displayDuration,
                mainImageVm, 
                tour.Slug, 
                discountPercent);
        }

        public TourImageViewModel TourImageViewModel(TourImage tourImage)
        {
            if (tourImage == null)
            {
                return null;
            }

            return new TourImageViewModel(
                Path.Combine(imageDirectory.TourImagesDirectory, tourImage.Url),
                tourImage.AltDescription.ToString());
        }

        private string GenerateDisplayPrice(TourPreview tour)
        {
            return tour.PriceBase.HasValue
                ? $"{tour.PriceBase.Value:N2} HRK + {tour.PricePerPerson:N2} HRK {mappingLocalization["per person"]}"
                : $"{tour.PricePerPerson:N2} HRK {mappingLocalization["per person"]}";
        }

        private string GenerateDisplayChildPrice(TourPreview tour)
        {
            return tour.PriceBase.HasValue
                ? $"{tour.PriceBase.Value:N2} HRK + {tour.PricePerChild:N2} HRK {mappingLocalization["per child"]}"
                : $"{tour.PricePerChild:N2} HRK {mappingLocalization["per child"]}";
        }

        private static string GenerateDiscountPercent(TourPreview tour)
        {
            int discountPercent = Convert.ToInt32(tour.DiscountPercent);
            return discountPercent.ToString();
        }

        private static string GenerateDisplayDuration(TourPreview tour)
        {
            return Math.Round(tour.Duration, 1).ToString(CultureInfo.InvariantCulture);
        }

        private static string GenerateDisplayDepartureTimes(IEnumerable<TourTime> tourTimes)
        {
            var departureTimes = tourTimes
                .Where(t => t != null)
                .Select(tt => tt.StartAt)
                .ToArray();

            return departureTimes?.Any() == true
                ? departureTimes
                    .Select(t => t.ToString(@"hh\:mm"))
                    .Aggregate((acc, next) => $"{acc} {next}")
                : null;
        }

        private IEnumerable<SelectListItem> GenerateTourTimeSelectList(Tours tour)
        {
            var tourTimeSelectList = new List<SelectListItem>();
            if (tour.TourTimes.Any())
            {
                foreach (var tourTime in tour.TourTimes)
                {
                    var startAt = tourTime.StartAt.ToString(@"hh\:mm");
                    tourTimeSelectList.Add(new SelectListItem { Text = startAt, Value = startAt });
                }
            }

            return tourTimeSelectList.ToArray();
        }

        public TourViewModel ToViewModel(Tours tour)
        {
            var images = (tour.MainImage == null ? Enumerable.Empty<TourImage>() : new[] { tour.MainImage }).Concat(tour.Images);
            var imageVms = images.Select(i => TourImageViewModel(i)).ToArray();
            var sanitizedContent = tour.Content?.Replace("\\r\\n", string.Empty);
            var sanitizedIsIncluded = tour.IsIncluded?.Replace("\\r\\n", string.Empty);
            var sanitizedNotIncluded = tour.NotIncluded?.Replace("\\r\\n", string.Empty);
            var timeNesting = tour.TimeNesting;

            var bookingModel = new TourBookingViewModel
            {
                TourTimeSelectList = GenerateTourTimeSelectList(tour)
            };

            var inactiveDuringVacation = tour.Type.Name == "scheduled";

            var vacations = new Dictionary<int, IEnumerable<Vacation>>();

            if (inactiveDuringVacation)
            {
                if (tour.Language == "eng")
                {
                    vacations = VacationDates.English;
                }
                else if (tour.Language == "esp")
                {
                    vacations = VacationDates.Spanish;
                }
            }

            return new TourViewModel
            {
                BookingModel = bookingModel,
                Images = imageVms,
                DisplayPrice = GenerateDisplayPrice(tour),
                DisplayChildPrice = GenerateDisplayChildPrice(tour),
                DisplayDepartureTimes = GenerateDisplayDepartureTimes(tour.TourTimes),
                Content = sanitizedContent,
                IsIncluded = sanitizedIsIncluded,
                NotIncluded = sanitizedNotIncluded,
                DiscountPercent = !tour.DiscountPercent.HasValue ? (int?)null : decimal.ToInt32(tour.DiscountPercent.Value),
                DisplayDuration = GenerateDisplayDuration(tour),
                Id = tour.Id,
                Title = tour.Title,
                Type = tour.Type.Name.UppercaseFirstLetter(),
                InactiveDuringVacation = inactiveDuringVacation,
                Vacations = vacations,
                TimeNesting = timeNesting,
                PaymentCallbackEndpoint = PaymentOptions.CallbackEndpoint,
                PaymentLanguage = CultureInfo.CurrentUICulture.Name == "en-US" ? "en" : "es",
                PaymentEndpoint = PaymentOptions.Endpoint
            };
        }

        public IEnumerable<TourPreviewViewModel> ToPreviewViewModels(IEnumerable<TourPreview> tours)
        {
            var tourVms = new List<TourPreviewViewModel>();
            foreach (var tour in tours)
            {
                tourVms.Add(ToPreviewViewModel(tour));
            }

            return tourVms.ToArray();
        }
    }
}