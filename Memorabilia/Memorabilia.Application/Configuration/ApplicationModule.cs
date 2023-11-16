using Memorabilia.Application.Services.Filters.Memorabilia;
using Memorabilia.Application.Services.Filters.Memorabilia.Rules;
using Memorabilia.Application.Services.Gallery.Memorabilia;
using Memorabilia.Application.Services.Tools.Profile;
using Memorabilia.Application.Services.Tools.Profile.Rules;

namespace Memorabilia.Application.Configuration;

public class ApplicationModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {   
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
