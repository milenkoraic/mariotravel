using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.BLL.Models.Transfer;
using MarioTravel.Core.BLL.Services.Language.Service;
using MarioTravel.Core.BLL.Services.Tour.Service;
using MarioTravel.Core.Configuration.Application;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Time.Service
{
    public class TimeService
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly ApplicationOptions applicationOptions;

        public TimeService(ConnectionFactory connectionFactory, IOptions<ApplicationOptions> applicationOptionsAccessor)
        {
            this.connectionFactory = EnsureArg.IsNotNull(connectionFactory, (nameof(connectionFactory)));
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
        }

        public List<TourTime> defaultTourBookingTimes = GenerateDefaultTourBookingTimes();
        public List<TourTime> defaultNestedTourBookingTimes = GenerateDefaultNestedBookingTimes();
        public List<TransferTime> defaultTransferBookingTimes = GenerateDefaultTransferBookingTimes();

        public static List<TourTime> GenerateDefaultTourBookingTimes()
        {
            var current = TimeSpan.FromHours(8);
            var endTime = TimeSpan.FromHours(20);

            var tourTimes = new List<TourTime>();
            while (current <= endTime)
            {
                tourTimes.Add(new TourTime { StartAt = current});
                current = current.Add(TimeSpan.FromMinutes(30));
            }

            return tourTimes;
        }

        public static List<TransferTime> GenerateDefaultTransferBookingTimes()
        {
            var current = TimeSpan.FromHours(8);
            var endTime = TimeSpan.FromHours(20);

            var defaultTransferBookingTimes = new List<TransferTime>();

            while (current <= endTime)
            {
                defaultTransferBookingTimes.Add(new TransferTime { StartAt = current });
                current = current.Add(TimeSpan.FromMinutes(30));
            }

            return defaultTransferBookingTimes;
        }

        public static List<TourTime> GenerateDefaultNestedBookingTimes()
        {
            var current = TimeSpan.FromHours(10);
            var endTime = TimeSpan.FromHours(17);

            var availibleNestedBookingTimes = new List<TourTime>();

            while (current <= endTime)
            {
                availibleNestedBookingTimes.Add(new TourTime { StartAt = current });
                current = current.Add(TimeSpan.FromMinutes(60));
            }

            return availibleNestedBookingTimes;
        }

        public async Task<Tours> GetAvailibleTourTimesAsync(int id)
        {
            using var connection = await connectionFactory.CreateOpenAsync();

            const string TOUR_SQL =
                @"SELECT
                        t.id,  
                        ttime.id,
                        ttime.tour_id,
                        ttime.start_at
                    FROM
                        tour t
                    LEFT JOIN
                        tour_time ttime ON ttime.tour_id = t.id
                    WHERE
                        t.id = @Id
                        AND t.application_id = @Application
                    ";

            var tourCache = new Dictionary<int, Tours>();

            await connection.QueryAsync<Tours, TourTime, Tours>(
                TOUR_SQL,
                (t, tt) =>
                {
                    if (!tourCache.TryGetValue(t.Id, out var queryTour))
                    {
                        tourCache.Add(t.Id, queryTour = t);
                    }


                    if (tt != null)
                    {
                        queryTour.TourTimes.Add(tt);
                    }

                    return queryTour;
                },
                new { Id = id, Application = applicationOptions.ApplicationId },
                splitOn: "id");

            var tour = tourCache.Values.FirstOrDefault();

            return tour;
        }

        public async Task<Tours> GetNestedBookingTimesAsync(int id, DateTime date)
        {
            const string NESTED_TIMES_SQL =
                @"SELECT
                        t.id,
                        t.title,
                        ttn.tour_id,
                        ttn.start_at
                    FROM
                        tour t
                    LEFT JOIN
                        tour_time_nesting ttn ON t.id = @Id
                    WHERE 
                        @SelectionDate 
                    BETWEEN 
                        ttn.time_start_date 
                    AND 
                        ttn.time_end_date";

            using var connection = await connectionFactory.CreateOpenAsync();

            var tourCache = new Dictionary<int, Tours>();

            await connection.QueryAsync<Tours, TourTime, Tours>(
                NESTED_TIMES_SQL,
                (t, ttn) =>
                {
                    if (!tourCache.TryGetValue(t.Id, out var queryTour))
                    {
                        tourCache.Add(t.Id, queryTour = t);
                    }

                    if (ttn != null)
                    {
                        queryTour.TourTimes.Add(ttn);
                    }

                    return queryTour;
                },
                new { Id = id, SelectionDate = date },
                splitOn: "id, tour_id");

            var tour = tourCache.Values.FirstOrDefault();

            return tour;
        }
    }  
}