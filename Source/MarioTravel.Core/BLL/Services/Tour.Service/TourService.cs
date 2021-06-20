using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.BLL.Services.Language.Service;
using MarioTravel.Core.BLL.Services.Time.Service;
using MarioTravel.Core.Configuration.Application;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Tour.Service
{
    public class TourService
    {
        private readonly ApplicationOptions applicationOptions;
        private readonly IHostEnvironment hostingEnvironment;
        private readonly ConnectionFactory connectionFactory;
        private readonly LanguageService languageService;
        private readonly TimeService timeService;



        public TourService(
            IHostEnvironment hostingEnvironment,
            IOptions<ApplicationOptions> applicationOptionsAccessor,
            ConnectionFactory connectionFactory,
            LanguageService languageService,
            TimeService timeService)
        {
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
            this.connectionFactory = EnsureArg.IsNotNull(connectionFactory, (nameof(connectionFactory)));
            this.languageService = EnsureArg.IsNotNull(languageService, nameof(languageService));
            this.timeService = EnsureArg.IsNotNull(timeService, nameof(timeService));
            this.hostingEnvironment = EnsureArg.IsNotNull(hostingEnvironment, nameof(hostingEnvironment));
        }

        public async Task<Tours> GetTourAsync(int id)
        {
            using var connection = await connectionFactory.CreateOpenAsync();

            const string TOUR_SQL =
                @"SELECT
                        t.id,
                        t.title,
                        t.description,
                        t.content,
                        t.is_included,
                        t.not_included,
                        t.price_base,
                        t.price_per_person,
                        t.discount_percent,
                        t.duration,
                        t.slug,
                        t.time_nesting,
                        t.application_id,
                        ttype.id,
                        ttype.name,
                        ttime.id,
                        ttime.tour_id,
                        ttime.start_at
                    FROM
                        tour t
                    INNER JOIN
                        tour_type ttype ON t.tour_type_id = ttype.id
                    LEFT JOIN
                        tour_time ttime ON ttime.tour_id = t.id
                    WHERE
                        t.id = @Id
                        AND t.application_id = @Application
                    ";

            var tourCache = new Dictionary<int, Tours>();

            await connection.QueryAsync<Tours, TourType, TourTime, Tours>(
                TOUR_SQL,
                (t, ttype, tt) =>
                {
                    if (!tourCache.TryGetValue(t.Id, out var queryTour))
                    {
                        tourCache.Add(t.Id, queryTour = t);
                    }

                    if (queryTour.Type == null)
                    {
                        queryTour.Type = ttype;
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

            if (tour == null)
            {
                return null;
            }

            const string IMAGE_SQL = @"SELECT
                        id,
                        tour_id,
                        url,
                        alt_description
                    FROM
                        tour_image
                    WHERE
                        tour_id = @TourId
                        AND application_id = @Application
                        AND is_active = TRUE
                    ORDER BY ordinal ASC";

            var dbImages = await connection.QueryAsync<TourImage>(IMAGE_SQL, new { TourId = id, Application = applicationOptions.ApplicationId });

            tour.MainImage = dbImages.FirstOrDefault();
            tour.Images.AddRange(dbImages.Skip(1));

            if (!tour.TourTimes.Any())
            {
                tour.TourTimes.AddRange(timeService.defaultTourBookingTimes);
            }

            if (tour.PriceBase.HasValue)
            {
                tour.PriceBase = GetTourPrice(tour.PriceBase.Value);
            }
            tour.PricePerPerson = GetTourPrice(tour.PricePerPerson);

            return tour;
        }

        public async Task<IEnumerable<TourPreview>> GetTourPreviewsAsync(GetToursPreviewFilter filter)
        {
            using var connection = await connectionFactory.CreateOpenAsync();

            var sql =
                @"SELECT
                        t.id,
                        t.title,
                        t.description,
                        t.price_base,
                        t.price_per_person,
                        t.duration,
                        t.slug,
                        t.discount_percent,
                        t.language_id,
                        t.application_id,
                        tt.id,
                        tt.tour_id,
                        tt.start_at
                    FROM
                        (SELECT
                            id,
                            title,
                            description,
                            price_base,
                            price_per_person,
                            duration,
                            slug,
                            discount_percent,
                            language_id,
                            application_id
                        FROM
                            tour
                        WHERE
                            application_id = @Application
                            AND tour_type_id = @TypeId) t
                    LEFT JOIN
                        tour_time tt ON t.id = tt.tour_id
                    ORDER BY
                         t.title ASC";

            object queryParams = null;

            queryParams = new
            {
                filter.TypeId,
                Application = applicationOptions.ApplicationId
            };

            var cache = new Dictionary<int, TourPreview>();
            await connection.QueryAsync<TourPreview, TourTime, TourPreview>(
                sql,
                (t, tt) =>
                {
                    if (!cache.TryGetValue(t.Id, out var tour))
                    {
                        cache.Add(t.Id, tour = t);
                    }

                    if (tt != null)
                    {
                        tour.TourTimes.Add(tt);
                    }

                    return tour;
                },
                queryParams,
                splitOn: "id");

            var toursIds = cache.Values.Select(t => t.Id).ToArray();
            var images = await connection.QueryAsync<TourImage>(
                @"SELECT
                        id,
                        tour_id,
                        url,
                        alt_description
                    FROM (
                        SELECT
                            id,
                            tour_id,
                            url,
                            alt_description,
                            ROW_NUMBER() OVER (PARTITION BY tour_id ORDER BY ordinal ASC) as row_number
                        FROM
                            tour_image
                        WHERE
                            tour_id = ANY(@Ids)
                            AND is_active = TRUE
                            AND application_id = @Application
                    ) AS ordered_images
                    WHERE row_number = 1;",
                new
                {
                    Ids = toursIds,
                    Application = applicationOptions.ApplicationId
                });

            foreach (var image in images)
            {
                if (cache.ContainsKey(image.TourId))
                {
                    cache[image.TourId].MainImage = image;
                }
            }

            return cache.Values.Select(t =>
            {
                if (t.PriceBase.HasValue)
                {
                    t.PriceBase = GetTourPrice(t.PriceBase.Value);
                }
                t.PricePerPerson = GetTourPrice(t.PricePerPerson);

                return t;
            });
        }

        public async Task<IEnumerable<TourType>> GetTourTypesAsync()
        {
            using var connection = await connectionFactory.CreateOpenAsync();
            return await connection.QueryAsync<TourType>(@"SELECT id, name FROM tour_type WHERE is_active = TRUE AND application_id = @Application", new
            {
                Application = applicationOptions.ApplicationId
            });
        }

        private decimal GetTourPrice(decimal price)
        {
            if (!hostingEnvironment.IsProduction())
            {
                return price / 100M;
            }

            return price;
        }
    }
}