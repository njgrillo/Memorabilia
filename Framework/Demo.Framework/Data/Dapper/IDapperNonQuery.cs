using System.Threading.Tasks;

namespace Demo.Framework.Data.Dapper
{
    public interface IDapperNonQuery<in TDatabase> where TDatabase : IDapperDatabase
    {
        Task Execute(TDatabase database);
    }
}
