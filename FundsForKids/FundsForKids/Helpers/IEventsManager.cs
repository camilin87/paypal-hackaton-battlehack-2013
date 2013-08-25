using System.Collections.Generic;
using FundsForKids.Models;

namespace FundsForKids.Helpers
{
    public interface IEventsManager
    {
        Event Event(int eventId);
        void RecordDonation(int eventId, decimal amount, string senderEmail);
        Event SaveEvent(Event entity, string userName, List<int> denominations );
        Coordinator CreateCoordinator(string paypalEmail, string userId);
        List<Denomination> Denominations();
        List<Denomination> Denominations(int eventId);
        Coordinator Coordinator(string userName);
        List<Event> Events();
    }
}
