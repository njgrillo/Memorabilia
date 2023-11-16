using Memorabilia.Application.Services.Admin.Management.Accomplishments;
using Memorabilia.Application.Services.Admin.Management.AllStars;
using Memorabilia.Application.Services.Admin.Management.Awards;
using Memorabilia.Application.Services.Autographs.Inscriptions;
using Memorabilia.Application.Services.Interfaces;
using Memorabilia.Application.Services.Projects;

namespace Memorabilia.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IApplicationStateService, ApplicationStateService>();
        services.AddSingleton<AccomplishmentManagementService>();
        services.AddSingleton<AllStarManagementService>();
        services.AddSingleton<AwardManagementService>();
        services.AddSingleton<PersonFilterService>();
        services.AddSingleton<ProjectAutographPersonLinkService>();
        services.AddSingleton<ProjectMemorabiliaTeamLinkService>();
        services.AddSingleton<SuggestedInscriptionService>();
        services.AddSingleton<TeamFilterService>();
    }
}
