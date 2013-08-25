using System;
using System.Collections.Generic;

namespace FundsForKids.Models
{
    public partial class Donation
    {
        public long DonationId { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public string SenderEmail { get; set; }
        public Nullable<int> Amoun { get; set; }
        public Nullable<long> EventId { get; set; }
    }
}
