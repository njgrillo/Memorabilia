namespace Memorabilia.Repository.Interfaces;

public interface ITransaction
{
    void CommitTransaction();

    IDbContextTransaction GetTransaction();

    void RollbackTransaction();
}
