namespace Memorabilia.Repository
{
    public abstract class BaseRepository<T> where T : DomainEntity
    {
        public BaseRepository(DomainContext context)
        {
            context.Set<T>().Where(t => 1 == 0).Load();
        }

        public BaseRepository(MemorabiliaContext context)
        {
            context.Set<T>().Where(t => 1 == 0).Load();
        }
    }
}
