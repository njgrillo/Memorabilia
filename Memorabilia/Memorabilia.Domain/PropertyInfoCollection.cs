namespace Memorabilia.Domain;

public class PropertyInfoCollection : KeyedCollection<string, PropertyInfo>
{
    public PropertyInfoCollection() { }

    public PropertyInfoCollection([NotNull] IEnumerable<PropertyInfo> properties)
    {
        foreach (var property in properties)
        {
            Add(property);
        }
    }

    protected override string GetKeyForItem(PropertyInfo item)
        => item.Name;
}
