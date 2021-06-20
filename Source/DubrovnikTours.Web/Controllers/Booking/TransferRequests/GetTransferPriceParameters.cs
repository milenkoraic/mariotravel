using MarioTravel.Core.BLL.Services.Transfer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers.Booking.TransferRequests
{
    [ApiController]
    public class GetTransferPriceParameters : ControllerBase
    {
        private readonly TransferService transferService;

        public GetTransferPriceParameters(TransferService transferService)
        {
            this.transferService = transferService;
        }

        [Route("api/prices/google/map/transfer/price/{distance}")]
        [HttpGet]
        public async Task<IActionResult> GetTransferPrices(decimal distance)
        {
            var transfer = await transferService.GetTransferAsync();

            var smallGroupPrice = transfer.SmallGroupTransferPrice ?? 0;
            var mediumGroupPrice = transfer.MediumGroupTransferPrice ?? 0;
            var suvStartPriceSmall = transfer.SuvStartPriceSmall ?? 0;
            var suvStartPriceLarge = transfer.SuvStartPriceLarge ?? 0;
            var vanStartPriceSmall = transfer.VanStartPriceSmall ?? 0;
            var vanStartPriceLarge = transfer.VanStartPriceLarge ?? 0;

            decimal smallSuvPrice = 0;
            decimal smallVanPrice = 0;

            decimal mediumSuvPrice = 0;
            decimal mediumVanPrice = 0;

            if (distance > 10)
            {
                smallSuvPrice = distance * smallGroupPrice + suvStartPriceSmall;
                smallVanPrice = distance * mediumGroupPrice + vanStartPriceSmall;

                return Ok(new
                {
                    SmallGroupPrice = smallSuvPrice.ToString("0.00"),
                    MediumGroupPrice = smallVanPrice.ToString("0.00")
                });
            }

            else
            {
                mediumSuvPrice = distance * smallGroupPrice + suvStartPriceLarge;
                mediumVanPrice = distance * mediumGroupPrice + vanStartPriceLarge;

                return Ok(new
                {
                    SmallGroupPrice = mediumSuvPrice.ToString("0.00"),
                    MediumGroupPrice = mediumVanPrice.ToString("0.00")
                });
            }
        }
    }
}
