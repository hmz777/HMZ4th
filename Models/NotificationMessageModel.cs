﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Models
{
    public class NotificationMessageModel
    {
        public string NotificationId { get; set; }
        public NotificationType NotificationType { get; set; }
        public string NotificationMessage { get; set; }
    }
}