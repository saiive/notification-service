﻿using System.Threading.Tasks;
using Saiive.Notification.Abstractions.Model;

namespace Saiive.Notification.Abstractions
{
    public abstract class MessageHandler : IMessageHandler
    {
        public abstract string Type { get; }
        public abstract Task Send(NotifyMessage message);

        public virtual Task<NotifyMessage> Added(SubscriptionsEntity subscription, AddedInformation information)
        {
            subscription.IsEnabled = false;
            var confirmMessage = $"{information.Host}/api/activate/{subscription.RowKey}/{subscription.PartitionKey}";

            var notification = new NotifyMessage(subscription.NotificationConnectionString, subscription.RowKey,
                subscription.PartitionKey)
            {
                Message = confirmMessage,
                PubKey = subscription.PublicKey
            };

            return Task.FromResult(notification);
        }


        public virtual Task<NotifyMessage> Activated(SubscriptionsEntity subscription, ActivateInformation information)
        {
            var deactivateLink = $"{information.Host}/api/deactivate/{subscription.RowKey}/{subscription.PartitionKey}";
            var confirmMessage = $"Your subscription has been activated. To disable it use this link: {deactivateLink}";

            var notification = new NotifyMessage(subscription.NotificationConnectionString, subscription.RowKey,
                subscription.PartitionKey)
            {
                Message = confirmMessage,
                PubKey = subscription.PublicKey
            };


            return Task.FromResult(notification);
        }

        public virtual Task<NotifyMessage> Deactivated(SubscriptionsEntity subscription, DeactivateInformation information)
        {
            var activateLink = $"{information.Host}/api/activate/{subscription.RowKey}/{subscription.PartitionKey}";
            var confirmMessage = $"Your subscription has been deactivated. To activate it use this link: {activateLink}";

            var notification = new NotifyMessage(subscription.NotificationConnectionString, subscription.RowKey,
                subscription.PartitionKey)
            {
                Message = confirmMessage,
                PubKey = subscription.PublicKey
            };


            return Task.FromResult(notification);
        }


    }
}
