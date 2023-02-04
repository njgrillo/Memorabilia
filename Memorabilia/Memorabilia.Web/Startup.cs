using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments;
using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards;

namespace Memorabilia.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDataProtection()
                .SetApplicationName("Memorabilia")
                .SetDefaultKeyLifetime(TimeSpan.FromDays(180));            

        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddDbContext<MemorabiliaContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        services.AddTransient<CommandRouter>();
        services.AddTransient<QueryRouter>();
        services.AddMediatR(typeof(GetCommissioner).Assembly);

        services.AddSingleton<AuthenticationValidator>();
        services.AddSingleton<AutographValidator>();
        services.AddSingleton<BammerValidator>();
        services.AddSingleton<BaseballValidator>();
        services.AddSingleton<BasketballValidator>();
        services.AddSingleton<BatValidator>();
        services.AddSingleton<BobbleheadValidator>();
        services.AddSingleton<BookValidator>();
        services.AddSingleton<CanvasValidator>();
        services.AddSingleton<CardValidator>();
        services.AddSingleton<CerealBoxValidator>();
        services.AddSingleton<DocumentValidator>();
        services.AddSingleton<DrumValidator>();
        services.AddSingleton<FigureValidator>();
        services.AddSingleton<FirstDayCoverValidator>();
        services.AddSingleton<FootballValidator>();
        services.AddSingleton<GloveValidator>();
        services.AddSingleton<GolfballValidator>();
        services.AddSingleton<GuitarValidator>();
        services.AddSingleton<HatValidator>();
        services.AddSingleton<HeadBandValidator>();
        services.AddSingleton<HelmetValidator>();
        services.AddSingleton<HockeyStickValidator>();
        services.AddSingleton<IndexCardValidator>();
        services.AddSingleton<InscriptionValidator>();
        services.AddSingleton<JerseyValidator>();
        services.AddSingleton<JerseyNumberValidator>();
        services.AddSingleton<LithographValidator>();
        services.AddSingleton<MagazineValidator>();
        services.AddSingleton<MemorabiliaItemValidator>();
        services.AddSingleton<PaintingValidator>();
        services.AddSingleton<PantValidator>();
        services.AddSingleton<PhotoValidator>();
        services.AddSingleton<PinFlagValidator>();
        services.AddSingleton<PlayingCardValidator>();
        services.AddSingleton<PosterValidator>();
        services.AddSingleton<PuckValidator>();
        services.AddSingleton<PylonValidator>();
        services.AddSingleton<ShirtValidator>();
        services.AddSingleton<ShoeValidator>();
        services.AddSingleton<SoccerballValidator>();
        services.AddSingleton<TennisballValidator>();
        services.AddSingleton<TennisRacketValidator>();
        services.AddSingleton<TicketValidator>();
        services.AddSingleton<TrunkValidator>();
        services.AddSingleton<WristBandValidator>();

        services.AddSingleton<AccomplishmentRuleFactory>();
        services.AddSingleton<AwardRuleFactory>();
        services.AddSingleton<SuggestedInscriptionService>();

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
        services.AddTransient<IPersonAwardRepository, PersonAwardCacheRepository>();

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

        services.AddMudServices(config =>
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
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles(); 
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new RepositoryModule());
        builder.RegisterModule(new ApplicationModule());
    }
}
