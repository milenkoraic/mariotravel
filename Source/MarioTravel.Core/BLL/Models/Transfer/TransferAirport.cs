using System;
using System.Collections.Generic;
using System.Text;

namespace MarioTravel.Core.BLL.Models.Transfer
{
    public class TransferAirport
    {
        public int Id { get; set; }
        public int AirportId { get; set; }
        public string AirportName { get; set; }
        public string AirportAddress { get; set; }
    }
}
