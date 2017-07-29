using SnackBar.Domain.Core.Events;
using System.Collections.Generic;

namespace SnackBar.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}