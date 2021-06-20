using CableCarDubrovnik.Web.Models;
using CableCarDubrovnik.Web.Models.Models;
using CableCarDubrovnik.Web.Models.Web.Models.Booking;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Booking.TourBooking;
using MarioTravel.Core.BLL.Services.Booking.Service;
using MarioTravel.Core.BLL.Services.Tour.Service;
using MarioTravel.Core.Configuration.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CableCarDubrovnik.Web.Controllers.Booking.TourBooking
{
    [Route("api/booking/deposit/tour")]
    public class BookingTourDepositController : Controller
    {
        private readonly ApplicationOptions applicationOptions;
        private readonly TourService tourService;
        private readonly BookingService tourBookingService;

        public BookingTourDepositController(
            IOptions<ApplicationOptions> applicationOptionsAccessor,
            TourService tourService, 
            BookingService tourBookingService)
        {
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
            this.tourService = tourService;
            this.tourBookingService = tourBookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepositBooking([FromBody]CreateTourBookingModel createTourBookingModel)
        {
            var tour = await tourService.GetTourAsync(createTourBookingModel.TourId);

            if (tour == null)
            {
                return BadRequest();
            }

            if (!DateTimeOffset.TryParseExact(createTourBookingModel.Date, "MM-dd-yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
            {
                ModelState.AddModelError(nameof(createTourBookingModel.Date), "Invalid date format.");

                return BadRequest(ModelState);
            }

            (bool, (string, string)) ValidateScheduledTourVacation(Dictionary<int, IEnumerable<Vacation>> langVacations)
            {
                const string modelErrorKey = nameof(createTourBookingModel.Date);
                var isError = false;
                string modelErrorMsg = null;

                if (langVacations.TryGetValue(date.Year, out var vacations))
                {
                    if (vacations.Any(vacation => date >= vacation.Start && date <= vacation.End))
                    {
                        modelErrorMsg = "Invalid tour date.";
                        isError = true;
                    }
                }

                return (isError, (modelErrorKey, modelErrorMsg));
            }

            var vacationError = false;
            if (tour.Type.Name == "scheduled")
            {
                Dictionary<int, IEnumerable<Vacation>> vacations = null;
                if (tour.Language == "eng")
                {
                    vacations = VacationDates.English;
                }
                else if (tour.Language == "esp")
                {
                    vacations = VacationDates.Spanish;
                }

                if (vacations != null)
                {
                    var (error, (modelKey, modelMsg)) = ValidateScheduledTourVacation(vacations);

                    if (error)
                    {
                        ModelState.AddModelError(modelKey, modelMsg);
                        vacationError = true;
                    }
                }
            }

            if (vacationError)
            {
                return BadRequest(ModelState);
            }

            var basePrice = tour.PriceBase ?? 0;

            var discountMultiplier = tour.DiscountPercent.HasValue
                ? (1 - (tour.DiscountPercent.Value / 100))
                : 1;

            var fullPrice = (basePrice + (createTourBookingModel.NumberOfPeople * tour.PricePerPerson) + (createTourBookingModel.NumberOfChildren * tour.PricePerChild));
            var numberOfAttenders = createTourBookingModel.NumberOfPeople + createTourBookingModel.NumberOfChildren;

            if (createTourBookingModel.PickUpPoint != "PILE MEETING POINT" && numberOfAttenders < 4)
            {
                fullPrice += numberOfAttenders * 50;
            }

            var depositPrice = fullPrice / 5;

            var externalId = Guid.NewGuid();

            var createDepositTourBooking = new CreateDepositTourBooking
            {
                Date = date,
                CreatedAt = DateTime.UtcNow,
                Duration = tour.Duration,
                Email = createTourBookingModel.Email,
                FullName = createTourBookingModel.FullName,
                Phone = createTourBookingModel.Phone,
                SendNotCompletedNotification = true,
                TourId = createTourBookingModel.TourId,
                TimeOfDay = createTourBookingModel.Time,
                FullPrice = fullPrice,
                PickUpPoint = createTourBookingModel.PickUpPoint,
                NumberOfPersons = createTourBookingModel.NumberOfPeople,
                NumberOfChildren = createTourBookingModel.NumberOfChildren,
                NumberOfBabies = createTourBookingModel.NumberOfBabies,
                AdditionalInfo = createTourBookingModel.AdditionalInfo,
                ExternalId = externalId,
                DepositPrice = depositPrice,
                ToBeCharged = fullPrice - depositPrice,
                ApplicationId = applicationOptions.ApplicationId
            };

            await tourBookingService.CreateDepositTourBookingAsync(createDepositTourBooking);

            return Ok(new
            {
                ExternalId = externalId,
                TotalPrice = depositPrice.ToString("0.00")
            });
        }
    }
}