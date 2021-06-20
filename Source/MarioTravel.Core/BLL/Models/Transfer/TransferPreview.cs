using System.Collections.Generic;

namespace MarioTravel.Core.BLL.Models.Transfer
{
    public class TransferPreview
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public List<TransferTime> TransferTimes { get; } = new List<TransferTime>();
        public List<TransferAirport> Airports { get; } = new List<TransferAirport>();
        public List<TransferDestination> Destinations { get; } = new List<TransferDestination>();
        public List<TransferCalculation> Calculations { get; } = new List<TransferCalculation>();
        public decimal? DiscountPercent { get; set; }
        public decimal? SmallGroupTransferPrice { get; set; }
        public decimal? SuvStartPriceSmall { get; set; }
        public decimal? SuvStartPriceLarge { get; set; }
        public decimal? MediumGroupTransferPrice { get; set; }
        public decimal? VanStartPriceSmall { get; set; }
        public decimal? VanStartPriceLarge { get; set; }
        public decimal? Distance { get; set; }
        public string Duration { get; set; }
        public int ApplicationId { get; set; }
    }
}