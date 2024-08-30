namespace Memorabilia.Repository.Extensions;

public static class DbContextExtensions
{
    public static IDbContextTransaction BeginTransaction(this DbContext context)
        => context.Database.BeginTransaction();

    public static void CommitTransaction(this DbContext context)
    {
        context.Database.CommitTransaction();
    }

    public static void ConfigureTemporalTable<TEntity>(
       this ModelBuilder modelBuilder,
       string periodStartColumnName = "ValidFrom",
       string periodEndColumnName = "ValidTo") where TEntity : class
    {
        modelBuilder.Entity<TEntity>(entity =>
        {
            entity.ToTable(
                tableBuilder =>
                {
                    tableBuilder.IsTemporal(
                        tableBuilderConfig =>
                        {
                            tableBuilderConfig.HasPeriodStart(periodStartColumnName);
                            tableBuilderConfig.HasPeriodEnd(periodEndColumnName);
                        });
                });
        });
    }

    public static void RollbackTransaction(this DbContext context)
    {
        context.Database.RollbackTransaction();
    }
}
