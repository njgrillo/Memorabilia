using Dapper;
using System;

namespace Demo.Framework.Data.Dapper.Mapping
{
    public interface IDapperTypeMap : SqlMapper.ITypeMap
    {
        Type MappedType { get; }
    }
}
