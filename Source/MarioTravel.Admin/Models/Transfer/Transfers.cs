namespace MarioTravel.Admin.Models.Transfer
{
    public class Transfers : TransferPreview
    {
        public new decimal? DiscountPercent { get; set; }
        public string Language { get; set; }
        public int MinutesBeforeDisposed { get; set; }
    }
}