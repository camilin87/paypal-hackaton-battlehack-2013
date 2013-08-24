using Funds4Kids.Models;

namespace Funds4Kids.Helpers
{
    public interface IEventsManager
    {
        EventInfo GetEvent(int eventId);
        void RecordDonation(int eventId, decimal amount, string senderEmail);
    }
}