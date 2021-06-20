using DubrovnikTours.Web.App.Infrastructure.TextModification;
using DubrovnikTours.Web.App.Localization.Mapping;
using DubrovnikTours.Web.Models;
using DubrovnikTours.Web.Models.Tour;
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

namespace DubrovnikTours.Web.Views.Mappers
{
    public class TourMapper
    {
        private readonly IStringLocalizer<MappingResources> mappingLocalizer;
        private readonly ImageDirectory imageDirectory;
        private readonly PaymentOptions TourPaymentOptions;

        public TourMapper(
            IOptions<PaymentOptions> tourPaymentOptionsAccessor,
            IOptions<ImageDirectory> imageDirectoryAccessor,
            IStringLocalizer<MappingResources> mappingLocalizerAccessor)

        {
            this.mappingLocalizer = EnsureArg.IsNotNull(mappingLocalizerAccessor);
            EnsureArg.IsNotNull(imageDirectoryAccessor, nameof(imageDirectoryAccessor));
            imageDirectory = imageDirectoryAccessor.Value;
            EnsureArg.IsNotNull(tourPaymentOptionsAccessor, nameof(tourPaymentOptionsAccessor));
            TourPaymentOptions = tourPaymentOptionsAccessor.Value;
        }

        private string GenerateDisplayPrice(TourPreview tour)
        {
            return tour.PriceBase.HasValue
                ? $"{tour.PriceBase.Value:N2} HRK + {tour.PricePerPerson.ToString("N2")} HRK {mappingLocalizer["per person"]}"
                : $"{tour.PricePerPerson:N2} HRK {mappingLocalizer["per person"]}";
        }

        private string GenerateDiscountPercent(TourPreview tour)
        {
            int discountPercent = Convert.ToInt32(tour.DiscountPercent);
            return discountPercent.ToString();
        }

        private string GenerateDisplayDuration(TourPreview tour)
        {
            return Math.Round(tour.Duration, 1).ToString(CultureInfo.InvariantCulture);
        }

        private string GenerateDisplayDepartureTimes(IEnumerable<TourTime> tourTimes)
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

        public TourPreviewViewModel TourPreviewViewModel(TourPreview tour)
        {
            var mainImageVm = TourImageViewModel(tour.MainImage);
            var displayPrice = GenerateDisplayPrice(tour);
            var displayDepartureTimes = GenerateDisplayDepartureTimes(tour.TourTimes);
            var displayDuration = GenerateDisplayDuration(tour);
            var discountPercent = GenerateDiscountPercent(tour);
            var languageId = tour.LanguageId;
            var applicationID = tour.ApplicationId;


            return new TourPreviewViewModel(
                tour.Id,
                tour.Title, 
                tour.Description, 
                displayPrice, 
                displayDepartureTimes, 
                displayDuration, 
                mainImageVm, 
                tour.Slug,
                discountPercent, 
                languageId,
                applicationID);
        }


        public IEnumerable<TourPreviewViewModel> TourPreviewViewModel(IEnumerable<TourPreview> tours)
        {
            var tourPreviewViewModels = new List<TourPreviewViewModel>();
            foreach (var tour in tours)
            {
                tourPreviewViewModels.Add(TourPreviewViewModel(tour));
            }

            return tourPreviewViewModels.ToArray();
        }

        public TourViewModel TourViewModel(Tours tour)
        {
            var images = (tour.MainImage == null ? Enumerable.Empty<TourImage>() : new[] { tour.MainImage }).Concat(tour.Images);
            var imageViewModels = images.Select(i => TourImageViewModel(i)).ToArray();
            var sanitizedContent = tour.Content?.Replace("\\r\\n", string.Empty);
            var sanitizedIsIncluded = tour.IsIncluded?.Replace("\\r\\n", string.Empty);
            var sanitizedNotIncluded = tour.NotIncluded?.Replace("\\r\\n", string.Empty);
            var applicationID = tour.ApplicationId;
            var timeNesting = tour.TimeNesting;

            var bookingModel = new TourBookingViewModel();

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
                Images = imageViewModels,
                DisplayPrice = GenerateDisplayPrice(tour),
                DisplayDepartureTimes = GenerateDisplayDepartureTimes(tour.TourTimes),
                Content = sanitizedContent,
                IsIncluded = sanitizedIsIncluded,
                NotIncluded = sanitizedNotIncluded,
                DiscountPercent = !tour.DiscountPercent.HasValue ? (int?)null : decimal.ToInt32(tour.DiscountPercent.Value),
                DisplayDuration = GenerateDisplayDuration(tour),
                Id = tour.Id,
                ApplicationId = tour.ApplicationId, 
                Title = tour.Title,
                TypeId = tour.Type.Id,
                TypeName = tour.Type.Name.ToLowerInvariant(),
                InactiveDuringVacation = inactiveDuringVacation,
                Vacations = vacations,
                TimeNesting = timeNesting,
                PaymentCallbackEndpoint = TourPaymentOptions.CallbackEndpoint,
                PaymentLanguage = CultureInfo.CurrentUICulture.Name == "en-US" ? "en" : "es",
                PaymentEndpoint = TourPaymentOptions.Endpoint
            };
        }
    }
}