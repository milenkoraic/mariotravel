using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DubrovnikTours.Web.Models.Transfer
{
    public class TransferBookingViewModel
    {
        [Required]
        [Display(Name = "Date")]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        public TimeSpan Time { get; set; }
      
        [Required]
        [Display(Name = "From Location")]
        public string FromLocation { get; set; }

        [Required]
        [Display(Name = "To Location")]
        public string ToLocation { get; set; }


        [Display(Name = "Distance")]
        public decimal TransferDistance { get; set; }


        [Display(Name = "Duration")]
        public string TransferDuration { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of people can't be less than 1.")]
        [Display(Name = "Number of People")]
        public int NumberOfPeople { get; set; } = 1;

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Additional info")]
        public string AdditionalInfo { get; set; }
        [Required]
        public int ApplicationId { get; set; }

    }
}
