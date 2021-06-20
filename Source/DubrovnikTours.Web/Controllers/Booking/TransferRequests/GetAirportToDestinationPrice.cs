using MarioTravel.Core.BLL.Services.Transfer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers.Booking.TransferRequests
{
    [ApiController]
    public class GetAirportToDestinationPrice : ControllerBase
    {
        private readonly TransferService transferService;

        public GetAirportToDestinationPrice(TransferService transferService)
        {
            this.transferService = transferService;
        }

        [Route("api/prices/transfer/airport/service/price/{airportId}/{groupType}/{destinationId}")]
        [HttpGet]
        public async Task<IActionResult> GetAirportTransferServicePrices(int airportId, int groupType, int destinationId)
        {
            var transfer = await transferService.GetAirportTransferServicePriceAsync(airportId, destinationId);

            var transferDistance = transfer.Distance;
            var transferDuration = transfer.Duration;

            foreach (var calculation in transfer.Calculations)
            {
                transferDistance = calculation.Distance;
                transferDuration = calculation.Duration.ToString();
            }

            decimal totalPrice = 0;
            var serviceCounted = "";

            if (transferDistance < 10) 
            {
                switch (groupType)
                {
                    case 1:
                        totalPrice = Convert.ToDecimal(transferDistance * transfer.SmallGroupTransferPrice + transfer.SuvStartPriceLarge);
                        serviceCounted = "SUV LARGE";
                        break;
                    case 2:
                        totalPrice = Convert.ToDecimal(transferDistance * transfer.MediumGroupTransferPrice + transfer.VanStartPriceLarge);
                        serviceCounted = "VAN LARGE";
                        break;
                    case 3:
                        totalPrice = 0;
                        serviceCounted = "REQUEST";
                        break;
                }
            }

            else
            {
                switch (groupType)
                {
                    case 1:
                        totalPrice = Convert.ToDecimal(transferDistance * transfer.SmallGroupTransferPrice + transfer.SuvStartPriceSmall);
                        serviceCounted = "SUV SMALL";
                        break;
                    case 2:
                        totalPrice = (decimal)(transferDistance * transfer.MediumGroupTransferPrice + transfer.VanStartPriceSmall);
                        serviceCounted = "VAN SMALL";
                        break;
                    case 3:
                        totalPrice = 0;
                        serviceCounted = "REQUEST";
                        break;
                }
            }

            return Ok(new
            {
                TotalPrice = totalPrice.ToString("0.00"),
                TransferDistance = transferDistance,
                TransferDuration = transferDuration,
                ServiceCounted = serviceCounted.ToString()
            });
        }
    }
}
