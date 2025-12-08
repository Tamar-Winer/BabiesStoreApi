using BabiesStoreApi.Interfaces;

namespace BabiesStoreApi.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"[EMAIL] Sent to {to}: {message}");
        }
    }
}
