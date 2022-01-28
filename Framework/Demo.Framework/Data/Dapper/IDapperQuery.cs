using System.Threading.Tasks;

namespace Demo.Framework.Data.Dapper
{
    public interface IDapperQuery<in TDatbase, TResult> where TDatbase : IDapperDatabase
    {
        Task<TResult> Execute(TDatbase database);
    }
}
