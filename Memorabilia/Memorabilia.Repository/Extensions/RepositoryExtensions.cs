namespace Memorabilia.Repository.Extensions;

public static class RepositoryExtensions
{
    public static void RegisterCachedRepositories(this IServiceCollection services)
    {
        services.AddTransient<AllStarRepository>();
        services.AddTransient<IAllStarRepository, AllStarCacheRepository>();

        services.AddTransient<CareerRecordRepository>();
        services.AddTransient<ICareerRecordRepository, CareerRecordCacheRepository>();

        services.AddTransient<ChampionRepository>();
        services.AddTransient<IChampionRepository, ChampionCacheRepository>();

        services.AddTransient<DraftRepository>();
        services.AddTransient<IDraftRepository, DraftCacheRepository>();

        services.AddTransient<FranchiseHallOfFameRepository>();
        services.AddTransient<IFranchiseHallOfFameRepository, FranchiseHallOfFameCacheRepository>();

        services.AddTransient<HallOfFameRepository>();
        services.AddTransient<IHallOfFameRepository, HallOfFameCacheRepository>();

        services.AddTransient<InternationalHallOfFameRepository>();
        services.AddTransient<IInternationalHallOfFameRepository, InternationalHallOfFameCacheRepository>();

        services.AddTransient<LeaderRepository>();
        services.AddTransient<ILeaderRepository, LeaderCacheRepository>();

        services.AddTransient<PersonAccomplishmentRepository>();
        services.AddTransient<IPersonAccomplishmentRepository, PersonAccomplishmentCacheRepository>();

        services.AddTransient<PersonAwardRepository>();
        //services.AddTransient<IPersonAwardRepository, PersonAwardCacheRepository>();

        services.AddTransient<PersonCollegeRepository>();
        services.AddTransient<IPersonCollegeRepository, PersonCollegeCacheRepository>();

        services.AddTransient<PersonRepository>();
        services.AddTransient<IPersonRepository, PersonCacheRepository>();

        services.AddTransient<PersonTeamRepository>();
        services.AddTransient<IPersonTeamRepository, PersonTeamCacheRepository>();

        services.AddTransient<RetiredNumberRepository>();
        services.AddTransient<IRetiredNumberRepository, RetiredNumberCacheRepository>();

        services.AddTransient<SingleSeasonRecordRepository>();
        services.AddTransient<ISingleSeasonRecordRepository, SingleSeasonRecordCacheRepository>();
    }
}
