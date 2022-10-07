namespace Memorabilia.Repository.Interfaces;

public interface IBaseRepository
{
    void CommitTransaction(DbContext context);

    IDbContextTransaction GetTransaction(DbContext context);

    void RollbackTransaction(DbContext context);
}
