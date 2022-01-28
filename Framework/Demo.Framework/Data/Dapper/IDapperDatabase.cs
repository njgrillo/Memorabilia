using System.Data;

namespace Demo.Framework.Data.Dapper
{
    public interface IDapperDatabase
    {
        IDbConnection CreateConnection();
    }
}
