using DubrovnikTours.Web.Models;
using DubrovnikTours.Web.Models.Booking;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Booking.TransferBooking;
using MarioTravel.Core.BLL.Services.Booking.Service;
using MarioTravel.Core.BLL.Services.Transfer.Service;
using MarioTravel.Core.Configuration.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers.TransferBooking
{
    [Route("api/booking/full/transfer")]
    public class BookingTransferFullController : Controller
    {
        private readonly ApplicationOptions applicationOptions;
        private readonly TransferService transferService;
        private readonly BookingService bookingService;

        public BookingTransferFullController(
            IOptions<ApplicationOptions> applicationOptionsAccessor,
            TransferService transferService, 
            BookingService bookingServiceAccessor)
        {
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
            this.transferService = transferService;
            this.bookingService = bookingServiceAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFullBooking([FromBody]CreateTransferBookingModel createTransferBookingModel)
        {
            var transfer = await transferService.GetTransferAsync();

            if (transfer == null)
            {
                return BadRequest();
            }

            if (!DateTimeOffset.TryParseExact(createTransferBookingModel.Date, "MM-dd-yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
            {
                ModelState.AddModelError(nameof(createTransferBookingModel.Date), "Invalid date format.");

                return BadRequest(ModelState);
            }

            (bool, (string, string)) ValidateScheduledTourVacation(Dictionary<int, IEnumerable<Vacation>> langVacations)
            {
                const string modelErrorKey = nameof(createTransferBookingModel.Date);
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
            if (transfer.TransferTimes.Any())
            {
                Dictionary<int, IEnumerable<Vacation>> vacations = null;
                if (transfer.Language == "eng")
                {
                    vacations = VacationDates.English;
                }
                else if (transfer.Language == "esp")
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

            var discountMultiplier = transfer.DiscountPercent.HasValue
                ? (1 - (transfer.DiscountPercent.Value / 100))
                : 1;

            decimal totalPrice = 0;

            var groupType = 0;
            if (createTransferBookingModel.NumberOfPeople <= 4)
            {
                groupType = 1;
            }
            else if (createTransferBookingModel.NumberOfPeople >= 5)
            {
                groupType = 2;
            }
            else
            {
                groupType = 3;
            }

            switch (groupType)
            {
                case 1:
                    if (createTransferBookingModel.TransferDistance < 10)
                    {
                        totalPrice = Convert.ToDecimal(createTransferBookingModel.TransferDistance * transfer.SmallGroupTransferPrice + transfer.SuvStartPriceLarge);
                    }
                    if (createTransferBookingModel.TransferDistance > 10)
                    {
                        totalPrice = Convert.ToDecimal(createTransferBookingModel.TransferDistance * transfer.SmallGroupTransferPrice + transfer.SuvStartPriceSmall);
                    }
                    break;
                case 2:
                    if (createTransferBookingModel.TransferDistance < 10)
                    {
                        totalPrice = Convert.ToDecimal(createTransferBookingModel.TransferDistance * transfer.MediumGroupTransferPrice + transfer.VanStartPriceLarge);
                    }
                    if (createTransferBookingModel.TransferDistance > 10)
                    {
                        totalPrice = Convert.ToDecimal(createTransferBookingModel.TransferDistance * transfer.MediumGroupTransferPrice + transfer.VanStartPriceSmall);
                    }
                    break;
            }

            var externalId = Guid.NewGuid();

            var createFullTranferBooking = new CreateFullTransferBooking
            {
                Date = date,
                NumberOfPersons = createTransferBookingModel.NumberOfPeople,
                CreatedAt = DateTime.UtcNow,
                Email = createTransferBookingModel.Email,
                FullName = createTransferBookingModel.FullName,
                Phone = createTransferBookingModel.Phone,
                SendNotCompletedNotification = true,
                TransferId = createTransferBookingModel.TransferId,
                TimeOfDay = createTransferBookingModel.Time,
                TotalPrice = totalPrice,
                AdditionalInfo = createTransferBookingModel.AdditionalInfo,
                FromLocation = createTransferBookingModel.FromLocation,
                ToLocation = createTransferBookingModel.ToLocation,
                TransferDistance = createTransferBookingModel.TransferDistance.ToString(),
                TransferDuration = createTransferBookingModel.TransferDuration,
                ExternalId = externalId,
                ApplicationId = applicationOptions.ApplicationId
            };

            await bookingService.CreateFullTransferBookingAsync(createFullTranferBooking);

            return Ok(new
            {
                ExternalId = externalId,
                TotalPrice = totalPrice.ToString("0.00")
            });
        }
    }
}