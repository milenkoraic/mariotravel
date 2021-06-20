using System;

namespace MarioTravel.Core.BLL.Models.Transfer
{
    public class TransferTime
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public TimeSpan StartAt { get; set; }
    }
}