namespace Memorabilia.Application.Configuration;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AutographFilterPredicateBuilder>().As<IAutographFilterPredicateBuilder>()
            .InstancePerDependency();

        builder.RegisterType<AutographFilterRuleFactory>().As<IAutographFilterRuleFactory>()
            .InstancePerDependency();               

        builder.RegisterType<DashboardItemFactory>().As<IDashboardItemFactory>()
            .InstancePerDependency();

        builder.RegisterType<MemorabiliaFilterPredicateBuilder>().As<IMemorabiliaFilterPredicateBuilder>()
            .InstancePerDependency();

        builder.RegisterType<MemorabiliaFilterRuleFactory>().As<IMemorabiliaFilterRuleFactory>()
            .InstancePerDependency();

        builder.RegisterType<ProfileRuleFactory>().As<IProfileRuleFactory>()
            .InstancePerDependency();

        builder.RegisterType<ProfileService>().As<IProfileService>()
            .InstancePerDependency();
    }
}
