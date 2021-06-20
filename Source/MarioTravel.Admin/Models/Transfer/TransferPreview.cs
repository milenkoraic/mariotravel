using System.Collections.Generic;

namespace MarioTravel.Admin.Models.Transfer
{
    public class TransferPreview
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public List<TransferTime> TransferTimes { get; } = new List<TransferTime>();
        public string Slug { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? SmallGroupTransferPrice { get; set; }
        public decimal? SuvStartPriceSmall { get; set; }
        public decimal? SuvStartPriceLarge { get; set; }
        public decimal? MediumGroupTransferPrice { get; set; }
        public decimal? VanStartPriceSmall { get; set; }
        public decimal? VanStartPriceLarge { get; set; }
    }
}