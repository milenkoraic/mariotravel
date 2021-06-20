using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CableCarDubrovnik.Web.Models.Tour
{
    public class TourBookingViewModel
    {
        [Required]
        [Display(Name = "Date")]
        public string DisplayDate { get; set; }

        [Required]
        [Display(Name = "Time")]
        public TimeSpan DisplayTourTime { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Pick Up Point")]
        public string PickUpPoint { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of people can't be less than 1.")]
        [Display(Name = "Number of People")]
        public int NumberOfPeople { get; set; } = 1;

        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; } = 0;

        [Display(Name = "Number of Babies")]
        public int NumberOfBabies { get; set; } = 0;

        [Display(Name = "Additional info")]
        public string AdditionalInfo { get; set; }

        public IEnumerable<SelectListItem> TourTimeSelectList { get; set; }
    }
}