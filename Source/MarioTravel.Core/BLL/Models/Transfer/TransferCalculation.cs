using System;
using System.Collections.Generic;
using System.Text;

namespace MarioTravel.Core.BLL.Models.Transfer
{
    public class TransferCalculation
    {
        public int Id { get; set; }
        public int AirportId { get; set; }
        public string AirportName { get; set; }
        public string AirportAddress { get; set; }
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public string DestinationAddress { get; set; }
        public decimal Distance { get; set; }
        public string Duration { get; set; }
    }
}
