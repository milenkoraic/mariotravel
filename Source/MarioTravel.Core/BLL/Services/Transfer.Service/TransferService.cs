using Dapper;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Transfer;
using MarioTravel.Core.BLL.Services.Time.Service;
using MarioTravel.Core.Configuration.Application;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Transfer.Service
{
	public class TransferService
	{
		private readonly ApplicationOptions applicationOptions;
		private readonly ConnectionFactory connectionFactory;
		public TimeService timeService;


		public TransferService(
			IOptions<ApplicationOptions> applicationOptionsAccessor,
			ConnectionFactory connectionFactory,
			TimeService timeService)
		{
			EnsureArg.IsNotNull(applicationOptionsAccessor, nameof(applicationOptionsAccessor));
			applicationOptions = EnsureArg.IsNotNull(applicationOptionsAccessor.Value, nameof(applicationOptionsAccessor.Value));
			this.timeService = EnsureArg.IsNotNull(timeService, nameof(timeService));
			this.connectionFactory = EnsureArg.IsNotNull(connectionFactory, (nameof(connectionFactory)));
		}

		public async Task<Transfers> GetTransferAsync()
		{
			const string TRANSFER_SQL =
				@"SELECT		
						t.id,
						t.title,
						t.discount_percent,
						t.small_group_transfer_price,
						t.medium_group_transfer_price,
						t.suv_start_price_small,
						t.van_start_price_small,
						t.suv_start_price_large,
						t.van_start_price_large,
						ta.airport_id,
						ta.airport_name,
						ta.airport_address,
						td.id,
						td.destination_id,
						td.destination_name,
						td.destination_address,
						tc.id,
						tc.distance,
						tc.duration,
						tc.application_id
					FROM
						transfer t
					LEFT JOIN
							transfer_airport ta ON ta.airport_id = ta.airport_id
					LEFT JOIN 
							transfer_destination td ON td.destination_id = td.destination_id
					LEFT JOIN 
							transfer_calculation tc ON tc.airport_id = ta.airport_id  AND tc.destination_id = td.destination_id
					LEFT JOIN 
							tour_time ttime ON ttime.tour_id = t.id
					WHERE
						 t.application_id = @Application";

			using var connection = await connectionFactory.CreateOpenAsync();

			var transferCache = new Dictionary<int, Transfers>();

			await connection.QueryAsync<Transfers, TransferAirport, TransferDestination, TransferCalculation, Transfers>(
				TRANSFER_SQL,
				(t, ta, td, tc) =>
				{
					if(!transferCache.TryGetValue(t.Id, out var queryTransfer))
					{
						transferCache.Add(t.Id, queryTransfer = t);
					}

					if(ta != null)
					{
						queryTransfer.Airports.Add(ta);
					}

					if(td != null)
                    {
						queryTransfer.Destinations.Add(td);
					}

                    if(tc !=null)
                    {
						queryTransfer.Calculations.Add(tc);
                    }

					return queryTransfer;
				},
				new { Application = applicationOptions.ApplicationId },
				splitOn: "id, airport_id, destination_id, application_id");

			var transfer = transferCache.Values.FirstOrDefault();

			if (transfer == null)
			{
				return null;
			}

			if (!transfer.TransferTimes.Any())
			{
				transfer.TransferTimes.AddRange(timeService.defaultTransferBookingTimes);
			}

			return transfer;
		}
		public async Task<Transfers> GetAirportTransferServicePriceAsync(int airportId, int destinatioId)
		{
			const string TRANSFER_SQL =
				@"SELECT		
						t.id,
						t.title,
						t.discount_percent,
						t.small_group_transfer_price,
						t.medium_group_transfer_price,
						t.suv_start_price_small,
						t.van_start_price_small,
						t.suv_start_price_large,
						t.van_start_price_large,
						ta.id,
						ta.airport_id,
						ta.airport_name,
						ta.airport_address,
						td.id,
						td.destination_id,
						td.destination_name,
						td.destination_address,
						tc.id,
						tc.airport_id,
						tc.destination_id,
						tc.distance,
						tc.duration
					FROM
						transfer t
					LEFT JOIN
							transfer_airport ta ON ta.airport_id = @AirportId
					LEFT JOIN 
							transfer_destination td ON td.destination_id = @DestinationId
					LEFT JOIN 
							transfer_calculation tc ON tc.airport_id = ta.airport_id  AND tc.destination_id = td.destination_id
					LEFT JOIN 
							tour_time ttime ON ttime.tour_id = t.id
					WHERE
						 t.application_id = @Application";

			using var connection = await connectionFactory.CreateOpenAsync();

			var transferCache = new Dictionary<int, Transfers>();

			await connection.QueryAsync<Transfers, TransferAirport, TransferDestination, TransferCalculation, Transfers>(
				TRANSFER_SQL,
				(t, ta, td, tc) =>
				{
					if (!transferCache.TryGetValue(t.Id, out var queryTransfer))
					{
						transferCache.Add(t.Id, queryTransfer = t);
					}

					if (ta != null)
					{
						queryTransfer.Airports.Add(ta);
					}

					if (td != null)
					{
						queryTransfer.Destinations.Add(td);
					}

					if(tc != null)
                    {
						queryTransfer.Calculations.Add(tc);
                    }

					return queryTransfer;
				},
				new {AirportId = airportId, DestinationId = destinatioId, Application = applicationOptions.ApplicationId },
				splitOn: "id");

			var transfer = transferCache.Values.FirstOrDefault();

			if (transfer == null)
			{
				return null;
			}

			return transfer;
		}
		private decimal GetTransferDistance(decimal distance)
		{

			return distance;
		}
	}
}