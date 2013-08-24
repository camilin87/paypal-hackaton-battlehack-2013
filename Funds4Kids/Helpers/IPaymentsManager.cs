namespace Funds4Kids.Helpers
{
    public interface IPaymentsManager
    {
        string Pay(string senderEmail, string receiverEmail, decimal amount, string returnUrl, string cancelUrl);
    }
}