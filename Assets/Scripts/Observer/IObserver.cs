namespace Observer.Core
{
	public interface IObserver
	{
        void OnNotification(string notification, object notifier, object data);
    }
}