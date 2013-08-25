using System;
using System.Collections.Generic;

namespace FundsForKids.Models
{
    public partial class Coordinator
    {
        public long CoordinatorId { get; set; }
        public string PaypalEmail { get; set; }
        public int UserId { get; set; }
    }
}
