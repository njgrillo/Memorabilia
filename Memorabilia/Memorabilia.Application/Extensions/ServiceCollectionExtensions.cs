namespace Memorabilia.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IApplicationStateService, ApplicationStateService>();
        services.AddSingleton<AllStarManagementService>();
        services.AddSingleton<AwardManagementService>();        
        services.AddSingleton<PersonFilterService>();
        services.AddSingleton<ProjectAutographPersonLinkService>();
        services.AddSingleton<ProjectMemorabiliaTeamLinkService>();
        services.AddSingleton<SingleOccurranceAccomplishmentService>();
        services.AddSingleton<SuggestedInscriptionService>();
        services.AddSingleton<TeamFilterService>();
        services.AddSingleton<YearRangeAccomplishmentService>();
    }
}
