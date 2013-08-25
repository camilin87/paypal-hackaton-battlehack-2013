using System;
using System.Collections.Generic;

namespace FundsForKids.Models
{
    public partial class Event
    {
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> Goal { get; set; }
        public Nullable<long> CoordinatorId { get; set; }
    }
}
