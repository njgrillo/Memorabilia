namespace Memorabilia.Repository.Configuration;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MemorabiliaContext>()
               .As<IMemorabiliaContext>()
               .InstancePerDependency();

        builder.RegisterType<DomainContext>()
               .As<IDomainContext>()
               .InstancePerDependency();

        builder.RegisterType<HistoryContext>()
               .As<IHistoryContext>()
               .InstancePerDependency();

        builder.RegisterAssemblyTypes(typeof(AutographRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces();

        builder.RegisterGeneric(typeof(DomainRepository<>))
               .As(typeof(IDomainRepository<>))
               .InstancePerDependency();

        builder.RegisterGeneric(typeof(HistoryRepository<>))
               .As(typeof(IHistoryRepository<>))
               .InstancePerDependency();
    }
}
