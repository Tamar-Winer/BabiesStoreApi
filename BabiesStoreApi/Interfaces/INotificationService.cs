namespace BabiesStoreApi.Interfaces
{
    public interface INotificationService
    {
        void Send(string to, string message);
    }
}
