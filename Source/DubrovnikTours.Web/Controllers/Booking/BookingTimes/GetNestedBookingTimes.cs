using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.BLL.Services.Time.Service;
using MarioTravel.Core.BLL.Services.Tour.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers.Booking.BookingTimes
{
    [ApiController]
    public class GetNestedBookingTimes : ControllerBase
    {
        private readonly TimeService timeService;

        public DateTime currentTime;

        public GetNestedBookingTimes(TimeService timeService)
        {
            this.timeService = timeService;
        }

        [Route("api/tour/booking/nested/times/availible/{id}/{date}")]
        [HttpGet]
        public async Task<IActionResult> GetAvailibleNestedBookingTimes(int id, DateTime date)
        {
            var tourTimesNested = await timeService.GetNestedBookingTimesAsync(id, date);
            var defaultNestedBookingTimes = timeService.defaultNestedTourBookingTimes;

            //GET CURRENT SERVER TIME
            DateTime currentServerTime = DateTime.Now;
            //CONVERT SERVER TIME TO UTC TIME
            DateTime currentTimeUTC = currentServerTime.ToUniversalTime();
            //SET TIMEZONE TO CONVERT UTC TIME (ZAGREB, CROATIA)
            TimeZoneInfo timeZoneIdentity = TimeZoneInfo.FindSystemTimeZoneById("Europe/Zagreb");
            //CONVERT UTC TIME TO ZAGREB TIMEZONE - STORE LOCAL TIME
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(currentTimeUTC, timeZoneIdentity);

            string currentDate = localTime.ToString("MM-dd-yyyy");
            string selectedDate = date.ToString("MM-dd-yyyy");

            var availibleNestedBookingTimes = new List<TourTime>();

            if (tourTimesNested != null)
            {

                currentTime = localTime.AddMinutes(15);

                if (currentDate == selectedDate)
                {
                    foreach (var nestedTime in tourTimesNested.TourTimes)
                    {
                        var startAt = nestedTime.StartAt;

                        if (startAt.TotalMinutes > currentTime.TimeOfDay.TotalMinutes)
                        {
                            availibleNestedBookingTimes.Add(new TourTime { StartAt = startAt });
                        }
                    }
                }

                else
                {
                    foreach (var nestedTime in tourTimesNested.TourTimes)
                    {
                        var startAt = nestedTime.StartAt;

                        availibleNestedBookingTimes.Add(new TourTime { StartAt = startAt });
                    }
                }

                return Ok(new
                {
                    AvailibleNestedBookingTimes = availibleNestedBookingTimes
                });
            }


            else
            {
                availibleNestedBookingTimes = defaultNestedBookingTimes;

                return Ok(new
                {
                    AvailibleNestedBookingTimes = availibleNestedBookingTimes
                });
            }

        }
    }
}
