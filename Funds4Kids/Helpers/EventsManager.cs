﻿using System.Data;
using Funds4Kids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace Funds4Kids.Helpers
{
    public class EventsManager : IEventsManager
    {

        public EventsManager()
        {
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