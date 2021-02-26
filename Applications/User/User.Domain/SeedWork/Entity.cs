using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CrossCutting.EventBus.Abstractions;

namespace User.Domain.SeedWork {
    public abstract class Entity {
        int? _requestedHashCode;
        Guid _Id;
        public virtual Guid Id {
            get {
                return _Id;
            }
            set {
                _Id = value;
            }
        }
        public int Version { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsDeleted { get; set; }

        private IList<UncommitedEvent> integrationEvents { get; set; }

        public void AddIntegrationEvent(IEvent @event)
        {
            integrationEvents = integrationEvents ?? new List<UncommitedEvent>();
            integrationEvents.Add(new UncommitedEvent(@event, Version + 1));
        }

        public IList<UncommitedEvent> GetUncommitedIntegrationEvents()
        {
            return integrationEvents;
        }

        public void SetVersion(int version)
        {
            Version = version;
        }

        public bool IsTransient () {
            return this.Id == default;
        }

        public override bool Equals (object obj) {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals (this, obj))
                return true;

            if (this.GetType () != obj.GetType ())
                return false;

            Entity item = (Entity) obj;

            if (item.IsTransient () || this.IsTransient ())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode () {
            if (!IsTransient ()) {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode () ^ 31;

                return _requestedHashCode.Value;
            } else
                return base.GetHashCode ();

        }
        public static bool operator == (Entity left, Entity right) {
            if (Object.Equals (left, null))
                return (Object.Equals (right, null)) ? true : false;
            else
                return left.Equals (right);
        }

        public static bool operator != (Entity left, Entity right) {
            return !(left == right);
        }
    }
}