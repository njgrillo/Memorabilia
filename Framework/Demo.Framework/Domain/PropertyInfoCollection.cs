using JetBrains.Annotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Demo.Framework.Domain
{
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
        {
            return item.Name;
        }
    }
}
