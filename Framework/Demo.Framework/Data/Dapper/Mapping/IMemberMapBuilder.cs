using System;
using System.Linq.Expressions;

namespace Demo.Framework.Data.Dapper.Mapping
{
    public interface IMemberMapBuilder<T>
    {
        void ToProperty(Expression<Func<T, object>> propertyExpression);
    }
}
