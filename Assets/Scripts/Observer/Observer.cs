namespace Observer.Core
{
    public abstract class Observer : IObserver
    {

        public abstract void OnNotification(string notification, object sender, object data);

    }
}
