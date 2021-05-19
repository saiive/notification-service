﻿using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notification.Abstractions
{
    public interface IMessageHandler
    {
        Task Send(NotifyMessage message);


        Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information);
        Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information);
        Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information);

        string Type { get; }
    }
}
