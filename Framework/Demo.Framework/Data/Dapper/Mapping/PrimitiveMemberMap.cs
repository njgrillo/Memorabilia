using Dapper;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Demo.Framework.Data.Dapper.Mapping
{
    public class PrimitiveMemberMap<T> : SqlMapper.IMemberMap, IMemberMapBuilder<T>
    {
        public PrimitiveMemberMap(string columnName)
        {
            ColumnName = columnName;
        }

        public string ColumnName { get; }

        public FieldInfo Field => null;

        public Type MemberType => Field?.FieldType ?? Property?.PropertyType ?? Parameter?.ParameterType;

        public ParameterInfo Parameter => null;

        public PropertyInfo Property { get; private set; }

        void IMemberMapBuilder<T>.ToProperty(Expression<Func<T, object>> propertyExpression)
        {
            //Property = Reflector.GetProperty(propertyExpression);
        }
    }
}
