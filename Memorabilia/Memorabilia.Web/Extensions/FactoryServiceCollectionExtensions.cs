using Memorabilia.Application.Services.Autographs.Inscriptions.Accomplishments;
using Memorabilia.Application.Services.Autographs.Inscriptions.Awards;

namespace Memorabilia.Web.Extensions;

public static class FactoryServiceCollectionExtensions
{
    public static void RegisterFactories(this IServiceCollection services)
    {
        services.AddSingleton<AccomplishmentRuleFactory>();
        services.AddSingleton<AwardRuleFactory>();
    }
}
