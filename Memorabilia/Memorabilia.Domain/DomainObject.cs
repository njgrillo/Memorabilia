namespace Memorabilia.Domain;

public abstract class DomainObject : IObjectStateAware
{
    private const int HashMultiplier
        = 31;

    private static readonly ConcurrentDictionary<Type, PropertyInfoCollection> NaturalKeyDictionary
        = new();

    [NotMapped]
    public virtual IEnumerable<PropertyInfo> NaturalKeys
        => GetOrCreateNaturalKeys();

    protected virtual Type GetTypeUnproxied()
        => GetType();

    private IEnumerable<PropertyInfo> GetOrCreateNaturalKeys()
        => NaturalKeyDictionary.GetOrAdd(GetTypeUnproxied(), x => new PropertyInfoCollection(CreateNaturalKeys()));

    protected virtual IEnumerable<PropertyInfo> CreateNaturalKeys()
        => GetTypeUnproxied().GetProperties().Where(pi => pi.IsDefined(typeof(NaturalKeyAttribute), true));

    public override bool Equals(object obj)
    {
        var compareTo = obj as DomainObject;

        if (ReferenceEquals(this, compareTo))
            return true;

        return compareTo != null && GetType() == compareTo.GetTypeUnproxied() && AreNaturalKeysEqual(compareTo);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = GetType().GetHashCode();

            hashCode = NaturalKeys.Select(property => property.GetValue(this, null))
                                  .Where(value => value != null)
                                  .Aggregate(hashCode, (current, value) => (current * HashMultiplier) ^ value.GetHashCode());

            return NaturalKeys.Any() ? hashCode : base.GetHashCode();
        }
    }

    public virtual bool AreNaturalKeysEqual(DomainObject compareTo)
    {
        if ((from property in NaturalKeys
             let valueOfThisObject = property.GetValue(this, null)
             let valueToCompareTo = property.GetValue(compareTo, null)
             where valueOfThisObject != null || valueToCompareTo != null
             where (valueOfThisObject == null) ^ (valueToCompareTo == null) || !valueOfThisObject.Equals(valueToCompareTo)
             select valueOfThisObject).Any())
        {
            return false;
        }

        return NaturalKeys.Any() || base.Equals(compareTo);
    }

    [NotMapped]
    public ObjectState ObjectState { get; protected set; }
}
