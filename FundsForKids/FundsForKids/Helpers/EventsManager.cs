using System.Collections.Generic;
using System.Data;
using System;
using FundsForKids.Models;
using System.Linq;

namespace FundsForKids.Helpers
{
    public class EventsManager : IEventsManager
    {

        public EventsManager()
        {
        }

        public Event Event(int eventId)
        {
            Event result = null;

            using (var dataContext = new Fund4KidsContext())
            {
                result = dataContext.Events.First(vent => vent.EventId == eventId);
            }

            return result;
        }

        public void RecordDonation(int eventId, decimal amount, string senderEmail)
        {
            using (var dataContext = new Fund4KidsContext())
            {
                dataContext.Donations.Add(new Donation() {EventId = eventId, SenderEmail = senderEmail, Amoun = (int)amount, TimeStamp = DateTime.Now});
                dataContext.SaveChanges();
            }
        }

        public Event SaveEvent(Event entity, string userName, List<int> denominations)
        {
            Event result;

            using (var dataContext = new Fund4KidsContext())
            {
                //var user = dataContext.UserProfiles.First(userp => userp.UserName.Equals(userName));
                //entity.CoordinatorId = dataContext.Coordinators.First(coordinator => coordinator.UserId == user.UserId).CoordinatorId;

                var coord = (from coordinator in dataContext.Coordinators
                            join user in dataContext.UserProfiles on coordinator.UserId equals user.UserId
                            where user.UserName.Equals(userName)
                            select coordinator).FirstOrDefault();

                entity.CoordinatorId = coord.CoordinatorId;

                if (entity.EventId == 0)
                    result = dataContext.Events.Add(entity);
                else
                {
                    result = dataContext.Events.Attach(entity);
                    var entry = dataContext.Entry(entity);
                    entry.State = EntityState.Modified;
                }

                //Get Event Id
                dataContext.SaveChanges();

                foreach(var denom in denominations)
                {
                    dataContext.EventDenominations.Add(new EventDenomination()
                                                           {EventId = entity.EventId, DenominationId = denom});
                }

                dataContext.SaveChanges();
            }

            return result;
        }

        public Coordinator CreateCoordinator(string paypalEmail, string userName)
        {
            Coordinator result = null;

            using (var dataContext = new Fund4KidsContext())
            {
                var user = dataContext.UserProfiles.First(userp => userp.UserName.Equals(userName));

                dataContext.Coordinators.Add(new Coordinator()
                {
                    UserId = user.UserId,
                    PaypalEmail = paypalEmail
                });

                dataContext.SaveChanges();
            }

            return result;
        }

        public List<Denomination> Denominations()
        {
            List<Denomination> result = null;

            using(var dataContext = new Fund4KidsContext())
            {
                result = dataContext.Denominations.Select(d => d).ToList();
            }

            return result;
        }

        public List<Denomination> Denominations(int eventId)
        {
            List<Denomination> result = null;

            using (var dataContext = new Fund4KidsContext())
            {
                var query = (from denomination in dataContext.Denominations
                             join eventDenomination in dataContext.EventDenominations on denomination.DenominationId
                                 equals eventDenomination.DenominationId
                             where eventDenomination.EventId == eventId
                             select denomination).Distinct();
                
                return query.ToList();
            }

            return result;
        }

        public Coordinator Coordinator(string userName)
        {
            Coordinator result= null;

            using (var dataContext = new Fund4KidsContext())
            {
                result = (from coordinator in dataContext.Coordinators
                             join user in dataContext.UserProfiles on coordinator.UserId equals user.UserId
                             where user.UserName.Equals(userName)
                             select coordinator).FirstOrDefault();
            }

            return result;
        }

        public List<Event> Events()
        {
            List<Event> result = null;

            using(var dataContext = new Fund4KidsContext())
            {
                result = dataContext.Events.Select(e => e).ToList();
            }

            return result;
        }
    }
}