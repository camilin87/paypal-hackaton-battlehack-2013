using System.Data;
using Funds4Kids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Funds4Kids.Helpers
{
    public class EventsManager : IEventsManager
    {
        private IFunds4KidsContext Db { get; set; }

        public EventsManager(IFunds4KidsContext dbContext)
        {
            Db = dbContext;
        }

        public EventInfo GetEvent(int eventId)
        {
            var eventResult = Db.EventInfos.First(ei => ei.Id == eventId);

            eventResult.Donations = Db.Donations.Where(d => d.EventInfoId == eventResult.Id).ToArray();
            
            eventResult.Denominations= Db.Denominations.Where(d => d.EventInfoId == eventResult.Id).ToArray();

            eventResult.EventCoordinator = Db.EventCoordinators.First(ec => ec.Id == eventResult.EventCoordinatorId);

            return eventResult;
        }

        public void RecordDonation(int eventId, decimal amount, string senderEmail)
        {
            throw new NotImplementedException();
        }

        public EventInfo SaveEvent(EventInfo entity)
        {
            EventInfo result;

            using (var dataContext = new Funds4KidsContext())
            {
                if (entity.Id == 0)
                    result = dataContext.EventInfos.Add(entity);
                else
                {
                    result = dataContext.EventInfos.Attach(entity);
                    var entry = dataContext.Entry(entity);
                    entry.State = EntityState.Modified;
                }

                dataContext.SaveChanges();
            }

            return result;
        }

    }
}