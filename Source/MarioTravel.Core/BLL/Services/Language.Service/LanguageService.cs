using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.Configuration.Application;
using Microsoft.Extensions.Options;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Language.Service
{
    public class LanguageService
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly ApplicationOptions applicationOptions;

        public LanguageService(ConnectionFactory connectionFactory, IOptions<ApplicationOptions> applicationOptionsAccessor)
        {
            this.connectionFactory = connectionFactory;
            EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
            applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
        }

        public async Task<TourLanguage> GetAsync(string cultureName)
        {
            using (var conn = await connectionFactory.CreateOpenAsync())
            {
                return await GetAsync(cultureName, conn);
            }
        }

        public async Task<TourLanguage> GetAsync(string cultureName, DbConnection connection)
        {
            return (await connection.QueryAsync<TourLanguage>(
                @"SELECT
                    id,
                    name,
                    culture_name
                FROM
                    tour_language
                WHERE
                    culture_name = @CultureName
                AND application_id =  @Application;",
                new { CultureName = cultureName, Application = applicationOptions.ApplicationId }))
                .Single();
        }
    }
}