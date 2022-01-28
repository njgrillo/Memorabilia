using Dapper;
using System.Collections.ObjectModel;

namespace Demo.Framework.Data.Dapper.Mapping
{
    internal class MemberMapCollection : KeyedCollection<string, SqlMapper.IMemberMap>
    {
        protected override string GetKeyForItem(SqlMapper.IMemberMap item)
        {
            return item.ColumnName;
        }
    }
}
