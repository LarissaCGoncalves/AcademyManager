namespace AcademyManager.Shared.Notifications
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications = [];

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool IsValid => !_notifications.Any();

        protected void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        protected void AddNotifications(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        protected void ClearNotifications()
        {
            _notifications.Clear();
        }

        public string ReadNotifications()
        {
            return string.Join(". ", _notifications.Select(n => n.Message));
        }
    }
}
