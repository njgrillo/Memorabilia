using Framework.Library.Handler;

namespace Memorabilia.Repository.Configuration;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MemorabiliaContext>().As<IMemorabiliaContext>()
            .InstancePerDependency();

        builder.RegisterType<DomainContext>().As<IDomainContext>()
            .InstancePerDependency();        

        builder.RegisterAssemblyTypes(typeof(AutographRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces();

        builder.RegisterGeneric(typeof(DomainRepository<>))
           .As(typeof(IDomainRepository<>))
        .InstancePerDependency();

        builder.RegisterType<ContextLoader>().As<IContextLoader>()
            .InstancePerDependency();
    }
}
