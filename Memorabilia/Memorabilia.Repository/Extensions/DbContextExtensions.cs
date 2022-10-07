namespace Memorabilia.Repository.Extensions;

public static class DbContextExtensions
{
    public static IDbContextTransaction BeginTransaction(this DbContext context)
    {
        return context.Database.BeginTransaction();
    }

    public static void CommitTransaction(this DbContext context)
    {
        context.Database.CommitTransaction();
    }

    public static void RollbackTransaction(this DbContext context)
    {
        context.Database.RollbackTransaction();
    }
}
