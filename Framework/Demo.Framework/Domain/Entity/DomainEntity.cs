using Demo.Framework.Domain;
using Demo.Framework.Domain.Event;
using JetBrains.Annotations;
using KellermanSoftware.CompareNetObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain.Entity
{
    public abstract class DomainEntity : DomainEntity<int>
    {
        public DomainEntity()
        {

        }

        public DomainEntity(int id) : base(id)
        {

        }

        //public virtual bool Exists => Id > 0;

        //public virtual bool IsDeleted { get; set; }        

        //public virtual bool IsNew => Id == 0;
    }

    public abstract class DomainEntity<TIdentifier> : DomainObject where TIdentifier : struct
    {
        private const int HashMultiplier = 31;

        private readonly ICompareLogic _compareLogic = new CompareLogic();

        private readonly List<IDomainEvent> _recordedEvents = new();

        private int? _cachedHashCode;

        protected DomainEntity() : this(default) { }

        protected DomainEntity(TIdentifier id)
        {
            id = id;
        }

        public virtual TIdentifier Id { get; protected set; }        

        private bool HasSameNonDefaultIdAs(DomainEntity<TIdentifier> compareTo)
        {
            return !IsTransient() && !compareTo.IsTransient() && Id.Equals(compareTo.Id);
        }

        //protected virtual void Publish([NotNull] IDomainEvent domainEvent)
        //{
        //    if (_recordedEvents.Any(publishedEvent => _compareLogic.Compare(publishedEvent, domainEvent).AreEqual))
        //        return;

        //    _recordedEvents.Add(domainEvent);
        //}

        protected virtual void Record([NotNull] IDomainEvent domainEvent)
        {
            if (_recordedEvents.Any(publishedEvent => _compareLogic.Compare(publishedEvent, domainEvent).AreEqual))
                return;

            _recordedEvents.Add(domainEvent);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DomainEntity<TIdentifier>;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null || GetType() != compareTo.GetTypeUnproxied())
                return false;

            if (HasSameNonDefaultIdAs(compareTo))
                return true;

            return IsTransient() && compareTo.IsTransient() && AreNaturalKeysEqual(compareTo);
        }

        public override int GetHashCode()
        {
            if (_cachedHashCode.HasValue)
                return _cachedHashCode.Value;

            if (IsTransient())
                _cachedHashCode = base.GetHashCode();
            else
            {
                unchecked
                {
                    var hashCode = GetType().GetHashCode();
                    _cachedHashCode = (hashCode * HashMultiplier) ^ Id.GetHashCode();
                }
            }

            return _cachedHashCode.Value;
        }

        public virtual IReadOnlyCollection<IDomainEvent> GetRecordedEvents()
        {
            var events = _recordedEvents.ToList();

            _recordedEvents.Clear();

            return events;
        }

        private static IEnumerable<IDomainEvent> CheckPropertiesForEvents(object item)
        {
            var events = new List<IDomainEvent>();

            if (item.GetType().GetInterface("IAuditableObject") != null)
                return events;

            foreach (
                var propertyInfo in
                item.GetType()
                    .GetProperties()
                    .Where(p => !p.PropertyType.IsCOMObject
                                && !p.PropertyType.IsEnum
                                && !p.PropertyType.IsPrimitive
                                && !p.PropertyType.IsValueType
                                && p.PropertyType.GetInterface("IAuditableObject") == null
                                &&
                                !(
                                   p.PropertyType.IsGenericType
                                   &&
                                   p.PropertyType.GetGenericArguments().Any(a => a.GetInterface("IAuditableOject") != null)
                                )
                          )
                    )
            {
                var value = propertyInfo.GetValue(item);

                switch (value)
                {
                    case null:
                        break;
                    case IDictionary dictionary:
                        foreach (var subItem in dictionary.Values)
                        {
                            events.AddRange(CheckValueOfPropertyForEvents(subItem));
                        }
                        break;
                    case IEnumerable enumerable:
                        foreach (var subItem in enumerable.OfType<object>())
                        {
                            events.AddRange(CheckValueOfPropertyForEvents(subItem));
                        }
                        break;
                    default:
                        events.AddRange(CheckValueOfPropertyForEvents(value));
                        break;
                }
            }

            return events;
        }

        private static IEnumerable<IDomainEvent> CheckValueOfPropertyForEvents(object item)
        {
            if (item is DomainEntity itemAsDomainEntity)
                return itemAsDomainEntity.GetRecordedEvents();

            return item != null ? CheckPropertiesForEvents(item) : new List<IDomainEvent>();
        }

        public override string ToString()
        {
            return $"Id: {Id}";
        }

        public virtual bool IsTransient()
        {
            return Id.Equals(default(TIdentifier));
        }
    }
}
