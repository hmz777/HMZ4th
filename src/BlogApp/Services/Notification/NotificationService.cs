using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class NotificationService
    {
        public event Action<NotificationMessageModel> OnMessageReceive;

        public void Show(NotificationMessageModel notificationMessageModel)
        {
            OnMessageReceive?.Invoke(notificationMessageModel);
        }
    }
}
