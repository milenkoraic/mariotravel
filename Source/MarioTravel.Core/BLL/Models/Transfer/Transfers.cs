namespace MarioTravel.Core.BLL.Models.Transfer
{
    public class Transfers : TransferPreview
    {
        public new decimal? DiscountPercent { get; set; }
        public string Language { get; set; }
        public new int ApplicationId { get; set; }
    }
}