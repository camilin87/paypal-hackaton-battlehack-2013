using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FundsForKids.Models
{
    public class EventModel
    {
        public Event Event { get; set; }
        public int Denomination1 { get; set; }
        public int Denomination2 { get; set; }
        public int Denomination3 { get; set; }
        public List<Denomination> AvailableDenoms { get; set; }

        public int Donations { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Paypal Email")]
        public string PaypalEmail { get; set; }

        [Display(Name = "Confirm Paypal Email")]
        [Compare("PaypalEmail", ErrorMessage = "The Paypal Email and confirmation Paypal Email do not match.")]
        public string ConfirmPaypalEmail { get; set; }
    }
}