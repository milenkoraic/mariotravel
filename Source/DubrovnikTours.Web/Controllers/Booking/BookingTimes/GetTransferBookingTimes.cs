using MarioTravel.Core.BLL.Models.Transfer;
using MarioTravel.Core.BLL.Services.Time.Service;
using MarioTravel.Core.BLL.Services.Transfer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers.Booking.BookingTimes
{
    [ApiController]
    public class GetTransferBookingTimes : ControllerBase
    {
        private readonly TimeService timeService;
        private readonly TransferService transferService;

        public GetTransferBookingTimes(TimeService timeService, TransferService transferService)
        {
            this.timeService = timeService;
            this.transferService = transferService;
        }

        public DateTime currentTime;

        [Route("api/transfer/booking/times/availible/{date}")]
        [HttpGet]
        public async Task<IActionResult> GetAvailibleTransferBookingTimesAsync(string date)
        {
            var customTransferBookingTimes = await transferService.GetTransferAsync();

            var transferTimesDefault = timeService.defaultTransferBookingTimes;

            //GET CURRENT SERVER TIME
            DateTime currentServerTime = DateTime.Now;
            //CONVERT SERVER TIME TO UTC TIME
            DateTime currentTimeUTC = currentServerTime.ToUniversalTime();
            //SET TIMEZONE TO CONVERT UTC TIME (ZAGREB, CROATIA)
            TimeZoneInfo timeZoneIdentity = TimeZoneInfo.FindSystemTimeZoneById("Europe/Zagreb");
            //CONVERT UTC TIME TO ZAGREB TIMEZONE - STORE LOCAL TIME
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(currentTimeUTC, timeZoneIdentity);

            string currentDate = localTime.ToString("MM-dd-yyyy");
            string selectedDate = date;

            var availibleTransferBookingTimes = new List<TransferTime>();

            currentTime = localTime.AddMinutes(60);

            if (customTransferBookingTimes.TransferTimes.Any())
            {
                if (currentDate == selectedDate)
                {
                    foreach (var transferTime in customTransferBookingTimes.TransferTimes)
                    {
                        var startAt = transferTime.StartAt;

                        if (startAt.TotalMinutes > currentTime.TimeOfDay.TotalMinutes)
                        {
                            availibleTransferBookingTimes.Add(new TransferTime { StartAt = startAt });
                        }
                    }
                }

                else
                {
                    foreach (var transferTime in customTransferBookingTimes.TransferTimes)
                    {
                        var startAt = transferTime.StartAt;

                        availibleTransferBookingTimes.Add(new TransferTime { StartAt = startAt });
                    }
                }
            }

            else
            {
                var startAt = TimeSpan.FromHours(localTime.AddHours(1).TimeOfDay.TotalMinutes);
                var endTime = TimeSpan.FromHours(20);

                var startOfDay = TimeSpan.FromHours(8);
                var endOfDay = TimeSpan.FromHours(24);

                if (startAt.TotalMinutes >= startOfDay.TotalMinutes && startAt.TotalMinutes <= endTime.TotalMinutes)
                {

                    if (startAt.TotalMinutes <= endTime.TotalMinutes)
                    {
                        availibleTransferBookingTimes.Add(new TransferTime { StartAt = startAt });
                        startAt = startAt.Add(TimeSpan.FromMinutes(30));
                    }
                }

                else if (startAt.TotalMinutes >= endTime.TotalMinutes && startAt.TotalMinutes <= endOfDay.TotalMinutes)
                {
                    availibleTransferBookingTimes = null;
                }

                else
                {
                    availibleTransferBookingTimes = transferTimesDefault;
                }

            }
            return Ok(new
            {
                AvailibleTransferBookingTimes = availibleTransferBookingTimes
            });
        }
    }
}
