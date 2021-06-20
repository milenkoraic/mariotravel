using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.BLL.Services.Time.Service;
using MarioTravel.Core.BLL.Services.Tour.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CableCarDubrovnik.Web.Controllers.Booking.BookingTimes
{
    [ApiController]
    public class GetTourBookingTimes : ControllerBase
    {
        private readonly TimeService timeService;
        private readonly TourService tourService;

        public DateTime currentTime;

        public GetTourBookingTimes(TimeService timeService, TourService tourService)
        {
            this.timeService = timeService;
            this.tourService = tourService;
        }

        [Route("/api/tour/booking/default/times/availible/{id}/{date}")]
        [HttpGet]
        public async Task<IActionResult> GetAvailibleTourBookingTimes(int id, string date)
        {
            var customTourBookingTimes = await tourService.GetTourAsync(id);

            var defaultTourBookingTimes = timeService.defaultTourBookingTimes;

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

            var availibleTourBookingTimes = new List<TourTime>();

            switch (customTourBookingTimes.Type.Id)
            {
                case 1:
                    currentTime = localTime.AddMinutes(15);
                    break;
                case 2:
                    currentTime = localTime.AddMinutes(60);
                    break;
                default:
                    currentTime = localTime;
                    break;
            }


            if (customTourBookingTimes.TourTimes.Any())
            {
                if (currentDate == selectedDate)
                {
                    foreach (var tourTime in customTourBookingTimes.TourTimes)
                    {
                        var startAt = tourTime.StartAt;

                        if (startAt.TotalMinutes > currentTime.TimeOfDay.TotalMinutes)
                        {
                            availibleTourBookingTimes.Add(new TourTime { StartAt = startAt });
                        }
                    }
                }

                else
                {
                    foreach (var tourTime in customTourBookingTimes.TourTimes)
                    {
                        var startAt = tourTime.StartAt;

                        availibleTourBookingTimes.Add(new TourTime { StartAt = startAt });
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
                        availibleTourBookingTimes.Add(new TourTime { StartAt = startAt });
                        startAt = startAt.Add(TimeSpan.FromMinutes(30));
                    }
                }

                else if (startAt.TotalMinutes >= endTime.TotalMinutes && startAt.TotalMinutes <= endOfDay.TotalMinutes)
                {
                    availibleTourBookingTimes = null;
                }

                else
                {
                    availibleTourBookingTimes = defaultTourBookingTimes;
                }

            }
            return Ok(new
            {
                AvailibleTourBookingTimes = availibleTourBookingTimes
            });
        }
    }
}
