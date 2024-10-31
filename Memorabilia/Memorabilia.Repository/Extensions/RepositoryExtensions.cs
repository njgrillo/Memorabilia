namespace Memorabilia.Repository.Extensions;

public static class RepositoryExtensions
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<AllStarRepository>();
        services.AddTransient<CareerFranchiseRecordRepository>();
        services.AddTransient<CareerRecordRepository>();
        services.AddTransient<ChampionRepository>();
        services.AddTransient<CollegeHallOfFameRepository>();
        services.AddTransient<DraftRepository>();
        services.AddTransient<FranchiseHallOfFameRepository>();
        services.AddTransient<HallOfFameRepository>();
        services.AddTransient<InternationalHallOfFameRepository>();
        services.AddTransient<LeaderRepository>();
        services.AddTransient<PersonAccomplishmentRepository>();
        services.AddTransient<PersonAwardRepository>();
        services.AddTransient<PersonCollegeRepository>();

        services.AddTransient<PersonRepository>();
        services.AddTransient<IPersonRepository, PersonCacheRepository>();

        services.AddTransient<PersonTeamRepository>();
        services.AddTransient<RetiredNumberRepository>();
        services.AddTransient<SingleSeasonFranchiseRecordRepository>();
        services.AddTransient<SingleSeasonRecordRepository>();
    }
}
