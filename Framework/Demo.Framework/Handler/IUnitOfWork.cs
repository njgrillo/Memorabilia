using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Handler
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
