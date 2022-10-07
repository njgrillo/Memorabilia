namespace Memorabilia.Repository;

public abstract class BaseRepository<T> : IBaseRepository where T : DomainEntity
{
    public BaseRepository(DomainContext context)
    {
        context.Set<T>().Where(t => 1 == 0).Load();
    }

    public BaseRepository(MemorabiliaContext context)
    {
        context.Set<T>().Where(t => 1 == 0).Load();
    }

    public void CommitTransaction(DbContext context)
    {
        context.CommitTransaction();
    }

    public IDbContextTransaction GetTransaction(DbContext context)
    {
        return context.Database.CurrentTransaction ?? context.BeginTransaction();
    }    

    public void RollbackTransaction(DbContext context)
    {
        context.RollbackTransaction();
    }
}
