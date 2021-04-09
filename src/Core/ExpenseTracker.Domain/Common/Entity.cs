using MediatR;
using System.Collections.Generic;

namespace ExpenseTracker.Domain.Common
{
    /// <summary>
    /// Base entity with common functionality for the id and domain events
    /// </summary>
    public abstract class Entity
    {
        private int? _requestedHashCode;

        public virtual int Id { get; set; }

        /// <summary>
        /// Collection of domain events that should be dispatched after the data is committed to the database.
        /// </summary>
        public ICollection<INotification> PostDbCommitDomainEvents
        {
            get;
            private set;
        }

        /// <summary>
        /// Collection of domain events that should be dispatched right before the data is committed
        /// to the database.
        /// </summary>
        public ICollection<INotification> PreDbCommitDomainEvents { get; private set; }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (right == null);
            else
                return left.Equals(right);
        }

        public void AddPostCommitDomainEvent(INotification eventItem)
        {
            PostDbCommitDomainEvents ??= new List<INotification>();
            PostDbCommitDomainEvents.Add(eventItem);
        }

        public void AddPreCommitDomainEvent(INotification eventItem)
        {
            PreDbCommitDomainEvents ??= new List<INotification>();
            PreDbCommitDomainEvents.Add(eventItem);
        }

        public void ClearPreCommitDomainEvents()
        {
            PreDbCommitDomainEvents?.Clear();
        }

        public void ClearPostCommitDomainEvents()
        {
            PostDbCommitDomainEvents?.Clear();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType())
                return false;
            Entity item = (Entity)obj;
            if (item.IsTransient() || IsTransient())
                return false;
            return item.Id == Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                _requestedHashCode ??= Id.GetHashCode() ^ 31;
                // XOR for random distribution. See: https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public bool IsTransient()
        {
            return Id == default;
        }

        public void RemovePostCommitDomainEvent(INotification eventItem)
        {
            PostDbCommitDomainEvents?.Remove(eventItem);
        }

        public void RemovePreCommitDomainEvent(INotification eventItem)
        {
            PreDbCommitDomainEvents?.Remove(eventItem);
        }
    }
}