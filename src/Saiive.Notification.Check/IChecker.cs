﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notification.Check
{
    public interface IChecker
    {
        Task<List<NotifyMessage>> CheckAlerts(List<SubscriptionsEntity> subscriptions);

        AlertType Type { get; }
    }
}
