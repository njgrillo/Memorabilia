using Dapper;
using Demo.Framework.Data.Dapper.Mapping;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Demo.Framework.Data.Dapper
{
    public abstract class DapperDatabase //: IDapperDatabase
    {
        protected abstract string ConnectionName { get; }

        protected virtual Func<string, IDbConnection> ConnectionFactory { get; } = connectionString => new SqlConnection(connectionString);

        public IDbConnection CreateConnection()
        {
            var connectionString = string.Empty; //get cs

            return ConnectionFactory(connectionString);
        }

        protected void RegisterTypeMap<TMap>() where TMap : IDapperTypeMap, new()
        {
            var typeMap = new TMap();

            SqlMapper.SetTypeMap(typeMap.MappedType, typeMap);
        }
    }
}
