namespace Memorabilia.Repository;

public class HistoryRepository<T>(HistoryContext context)
    : BaseRepository<T>(context), IHistoryRepository<T> where T : Domain.Entity
{
    protected readonly HistoryContext Context
        = context;

    protected IQueryable<T> Items
        => Context.Set<T>();

    public virtual async Task<T> Get(int id)
        => await Items.SingleOrDefaultAsync(item => item.Id == id);

    public async Task<T[]> GetAll()
        => await Items.ToArrayAsync();
}
