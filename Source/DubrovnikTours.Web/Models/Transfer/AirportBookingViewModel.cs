using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DubrovnikTours.Web.Models.Transfer
{
    public class AirportBookingViewModel
    {

        public IEnumerable<SelectListItem> AirportSelectList { get; set; }
        public IEnumerable<SelectListItem> DestinationSelectList { get; set; }

    }
}
