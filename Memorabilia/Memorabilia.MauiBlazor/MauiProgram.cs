namespace Memorabilia.MauiBlazor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()            
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Configuration.AddJsonFile("appsettings.json");

        builder.Services.AddDbContext<MemorabiliaContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        builder.Services.AddTransient<IMemorabiliaContext, MemorabiliaContext>();
        builder.Services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        builder.Services.AddTransient<IDomainContext, DomainContext>();
        builder.Services.AddTransient<CommandRouter>();
        builder.Services.AddTransient<QueryRouter>();
        builder.Services.AddTransient(typeof(IDomainRepository<>), typeof(DomainRepository<>));
        builder.Services.AddTransient<IAllStarRepository, AllStarRepository>();
        builder.Services.AddTransient<IAutographRepository, AutographRepository>();
        builder.Services.AddTransient<ICareerRecordRepository, CareerRecordRepository>();
        builder.Services.AddTransient<IChampionRepository, ChampionRepository>();       
        builder.Services.AddTransient<ICommissionerRepository, CommissionerRepository>();
        builder.Services.AddTransient<IContextLoader, ContextLoader>();
        builder.Services.AddTransient<IDraftRepository, DraftRepository>();
        builder.Services.AddTransient<IFranchiseHallOfFameRepository, FranchiseHallOfFameRepository>();
        builder.Services.AddTransient<IHallOfFameRepository, HallOfFameRepository>();
        builder.Services.AddTransient<IInternationalHallOfFameRepository, InternationalHallOfFameRepository>();
        builder.Services.AddTransient<IItemTypeBrandRepository, ItemTypeBrandRepository>();
        builder.Services.AddTransient<IItemTypeGameStyleTypeRepository, ItemTypeGameStyleTypeRepository>();
        builder.Services.AddTransient<IItemTypeLevelRepository, ItemTypeLevelRepository>();
        builder.Services.AddTransient<IItemTypeSizeRepository, ItemTypeSizeRepository>();
        builder.Services.AddTransient<IItemTypeSportRepository, ItemTypeSportRepository>();
        builder.Services.AddTransient<IItemTypeSpotRepository, ItemTypeSpotRepository>();        
        builder.Services.AddTransient<ILeaderRepository, LeaderRepository>();
        builder.Services.AddTransient<ILeaguePresidentRepository, LeaguePresidentRepository>();
        builder.Services.AddTransient<IPersonAccomplishmentRepository, PersonAccomplishmentRepository>();
        builder.Services.AddTransient<IPersonAwardRepository, PersonAwardRepository>();
        builder.Services.AddTransient<IPersonCollegeRepository, PersonCollegeRepository>();
        builder.Services.AddTransient<IPersonRepository, PersonRepository>();
        builder.Services.AddTransient<IPersonTeamRepository, PersonTeamRepository>();        
        builder.Services.AddTransient<IProfileRuleFactory, ProfileRuleFactory>();
        builder.Services.AddTransient<IProfileService, ProfileService>();
        builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
        builder.Services.AddTransient<IRetiredNumberRepository, RetiredNumberRepository>();
        builder.Services.AddTransient<ISingleSeasonRecordRepository, SingleSeasonRecordRepository>();
        builder.Services.AddTransient<ITeamChampionshipRepository, TeamChampionshipRepository>();
        builder.Services.AddTransient<ITeamConferenceRepository, TeamConferenceRepository>();
        builder.Services.AddTransient<ITeamDivisionRepository, TeamDivisionRepository>();
        builder.Services.AddTransient<ITeamLeagueRepository, TeamLeagueRepository>();
        builder.Services.AddTransient<ITeamRepository, TeamRepository>();
        builder.Services.AddMediatR(typeof(GetAccomplishmentTypes));

        builder.Services.AddTransient<AllStarRepository>();
        builder.Services.AddTransient<IAllStarRepository, AllStarCacheRepository>();

        builder.Services.AddTransient<CareerRecordRepository>();
        builder.Services.AddTransient<ICareerRecordRepository, CareerRecordCacheRepository>();

        builder.Services.AddTransient<ChampionRepository>();
        builder.Services.AddTransient<IChampionRepository, ChampionCacheRepository>();

        builder.Services.AddTransient<DraftRepository>();
        builder.Services.AddTransient<IDraftRepository, DraftCacheRepository>();

        builder.Services.AddTransient<FranchiseHallOfFameRepository>();
        builder.Services.AddTransient<IFranchiseHallOfFameRepository, FranchiseHallOfFameCacheRepository>();

        builder.Services.AddTransient<HallOfFameRepository>();
        builder.Services.AddTransient<IHallOfFameRepository, HallOfFameCacheRepository>();

        builder.Services.AddTransient<InternationalHallOfFameRepository>();
        builder.Services.AddTransient<IInternationalHallOfFameRepository, InternationalHallOfFameCacheRepository>();

        builder.Services.AddTransient<LeaderRepository>();
        builder.Services.AddTransient<ILeaderRepository, LeaderCacheRepository>();

        builder.Services.AddTransient<PersonAccomplishmentRepository>();
        builder.Services.AddTransient<IPersonAccomplishmentRepository, PersonAccomplishmentCacheRepository>();

        builder.Services.AddTransient<PersonAwardRepository>();
        builder.Services.AddTransient<IPersonAwardRepository, PersonAwardCacheRepository>();

        builder.Services.AddTransient<PersonCollegeRepository>();
        builder.Services.AddTransient<IPersonCollegeRepository, PersonCollegeCacheRepository>();

        builder.Services.AddTransient<PersonRepository>();
        builder.Services.AddTransient<IPersonRepository, PersonCacheRepository>();

        builder.Services.AddTransient<PersonTeamRepository>();
        builder.Services.AddTransient<IPersonTeamRepository, PersonTeamCacheRepository>();

        builder.Services.AddTransient<RetiredNumberRepository>();
        builder.Services.AddTransient<IRetiredNumberRepository, RetiredNumberCacheRepository>();

        builder.Services.AddTransient<SingleSeasonRecordRepository>();
        builder.Services.AddTransient<ISingleSeasonRecordRepository, SingleSeasonRecordCacheRepository>();

        //var autofacBuilder = new ContainerBuilder();
        //autofacBuilder.Populate(builder.Services);

        //autofacBuilder.RegisterModule(new RepositoryModule());
        //autofacBuilder.RegisterModule(new ApplicationModule());

        //autofacBuilder.Build();       

        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

        return builder.Build();
    }
}