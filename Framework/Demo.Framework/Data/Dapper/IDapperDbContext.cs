using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Demo.Framework.Data.Dapper
{
    public interface IDapperDbContext
    {
        Task ExecuteNonQuery<TDatabase>([NotNull] IDapperNonQuery<TDatabase> nonQuery) where TDatabase : class, IDapperDatabase;

        Task<TResult> ExecuteQuery<TDatabase, TResult>([NotNull] IDapperQuery<TDatabase, TResult> query) where TDatabase : class, IDapperDatabase;
    }
}
