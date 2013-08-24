using Funds4Kids.Models;
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

        public EventInfo GetEvent(int eventId)
        {
            //var result = Db.EventInfos.First(ei => ei.Id == eventId);


            //result.EventCoordinator = Db.EventCoordinators.First(ec => ec.Id == result.EventCoordinatorId);

            //result.

            //result.Denominations = Db.Denominations.Where(d => d.Amount == );

            //return result;

            throw new NotImplementedException();

        }

        public void RecordDonation(int eventId, decimal amount, string senderEmail)
        {
            throw new NotImplementedException();
        }
    }
}