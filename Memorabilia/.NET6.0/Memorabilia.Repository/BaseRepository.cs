using Framework.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public abstract class BaseRepository<T> where T : DomainEntity
    {
        public BaseRepository(Context context)
        {
            context.Set<T>().Where(t => 1 == 0).Load();
        }
    }
}
