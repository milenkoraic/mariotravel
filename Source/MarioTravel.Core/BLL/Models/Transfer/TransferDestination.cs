using System;
using System.Collections.Generic;
using System.Text;

namespace MarioTravel.Core.BLL.Models.Transfer
{
    public class TransferDestination
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public string DestinationAddress { get; set; }
    }
}
