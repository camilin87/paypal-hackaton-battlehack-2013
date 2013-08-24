using Funds4Kids.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Funds4Kids.Helpers
{
    public class EventsManager
    {
        private IFunds4KidsContext Db { get; set; }

        public EventsManager(IFunds4KidsContext dbContext)
        {
            Db = dbContext;
        }

        public EventDTO GetEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public void RecordDonation(int eventId, decimal amount, string senderEmail)
        {
            throw new NotImplementedException();
        }
    }
}