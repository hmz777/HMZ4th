using HMZ4th.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Services
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
