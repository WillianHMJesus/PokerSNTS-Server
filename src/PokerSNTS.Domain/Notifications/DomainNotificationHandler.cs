﻿using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace PokerSNTS.Domain.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void HandleNotification(ValidationResult validationResult)
        {
            foreach (var error in validationResult?.Errors ?? Enumerable.Empty<ValidationFailure>())
            {
                _notifications.Add(new DomainNotification("DomainValidation", error.ErrorMessage));
            }
        }

        public void HandleNotification(string key, string value)
        {
            _notifications.Add(new DomainNotification(key, value));
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
