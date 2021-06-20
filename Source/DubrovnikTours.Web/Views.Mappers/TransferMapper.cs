using DubrovnikTours.Web.Models;
using DubrovnikTours.Web.Models.Transfer;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Payment;
using MarioTravel.Core.BLL.Models.Transfer;
using MarioTravel.Core.Configuration.Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DubrovnikTours.Web.Views.Mappers
{
    public class TransferMapper
    {
        private readonly PaymentOptions paymentOptions;
        private readonly ApplicationOptions applicationOptions;

        public TransferMapper(IOptions<PaymentOptions> paymentOptionsAccessor, IOptions<ApplicationOptions> applicationOptionsAccessor)
        {
            EnsureArg.IsNotNull(paymentOptionsAccessor, nameof(paymentOptionsAccessor));
            paymentOptions = paymentOptionsAccessor.Value;
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
        }

        //GENERATE ONLY UNIQE AIRPORT VALUES FROM TRANSFER CALCULATION QUERY
        private IEnumerable<SelectListItem> GenerateAirportSelectList(Transfers transfer)
        {
            var airportSelectList = new List<SelectListItem>();

            var transferAirportList = new List<TransferAirport>();

            if (transfer.Airports.Any())
            {
                foreach (var airport in transfer.Airports)
                {
                    bool exists = transferAirportList.Where(ta => ta.AirportName.Contains(airport.AirportName)).Any();

                    if (!exists == true)
                    {
                        transferAirportList.Add(new TransferAirport { AirportName = airport.AirportName , AirportAddress = airport.AirportAddress});
                    }
                }

                foreach (var airport in transferAirportList)
                {
                    airportSelectList.Add(new SelectListItem { Text = airport.AirportName, Value = airport.AirportAddress });                
                }
                
            }

            else
            {
                var airportName = "NO AIRPORTS INSERTED";
                var airportAddress = "";
                airportSelectList.Add(new SelectListItem { Text = airportName, Value = airportAddress });
            }

            return airportSelectList.ToArray();
        }

        //GENERATE ONLY UNIQE DESTINATION VALUES FROM TRANSFER CALCULATION QUERY
        private IEnumerable<SelectListItem> GenerateDestinationSelectList(Transfers transfer)
        {
            var destinationSelectList = new List<SelectListItem>();

            var transferDestinationtList = new List<TransferDestination>();

            if (transfer.Destinations.Any())
            {
                foreach (var destination in transfer.Destinations)
                {
                    bool exists = transferDestinationtList.Where(ta => ta.DestinationName.Contains(destination.DestinationName)).Any();

                    if (!exists == true)
                    {
                        transferDestinationtList.Add(new TransferDestination { DestinationName = destination.DestinationName, DestinationAddress = destination.DestinationAddress});
                    }
                }

                foreach (var destination in transferDestinationtList)
                {
                    destinationSelectList.Add(new SelectListItem { Text = destination.DestinationName, Value = destination.DestinationAddress });
                }
            }
            
            else
            {
                var destinationtName = "NO DESTINATIONS INSERTED";
                var destinationAddress = "";

                destinationSelectList.Add(new SelectListItem { Text = destinationtName, Value = destinationAddress });
            }

            return destinationSelectList.ToArray();
        }


        public TransferViewModel ToTransferViewModel(Transfers transfer)
        {
            var bookingModel = new TransferBookingViewModel();

            var airportModel = new AirportBookingViewModel
            {
                AirportSelectList = GenerateAirportSelectList(transfer),
                DestinationSelectList = GenerateDestinationSelectList(transfer)
            };

            var inactiveDuringVacation = transfer.TransferTimes.Any();

            var vacations = new Dictionary<int, IEnumerable<Vacation>>();

            if (inactiveDuringVacation)
            {
                if (transfer.Language == "eng")
                {
                    vacations = VacationDates.English;
                }
                else if (transfer.Language == "esp")
                {
                    vacations = VacationDates.Spanish;
                }
            }

            return new TransferViewModel
            {
                BookingModel = bookingModel,
                AirportBookingModel =airportModel,
                DiscountPercent = !transfer.DiscountPercent.HasValue ? (int?)null : decimal.ToInt32(transfer.DiscountPercent.Value),
                Id = transfer.Id,
                ApplicationId = applicationOptions.ApplicationId,
                Title = transfer.Title,
                InactiveDuringVacation = inactiveDuringVacation,
                Vacations = vacations,
                PaymentCallbackEndpoint = paymentOptions.CallbackEndpoint,
                PaymentLanguage = CultureInfo.CurrentUICulture.Name == "en-US" ? "en" : "es",
                PaymentEndpoint = paymentOptions.Endpoint
            };
        }
    }
}