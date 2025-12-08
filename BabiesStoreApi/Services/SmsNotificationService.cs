using BabiesStoreApi.Interfaces;

namespace BabiesStoreApi.Services
{
    public class SmsNotificationService : INotificationService
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"[SMS] Sent to {to}: {message}");
        }
    }
}
