﻿namespace Memorabilia.Application.Configuration;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {   
        builder.RegisterType<DashboardItemFactory>().As<IDashboardItemFactory>()
            .InstancePerDependency();

        builder.RegisterType<GalleryRuleFactory>().As<IGalleryRuleFactory>()
            .InstancePerDependency();

        builder.RegisterType<GalleryService>().As<IGalleryService>()
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
