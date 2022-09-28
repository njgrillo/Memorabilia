namespace Memorabilia.Web
{
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
            services.AddTransient<IMemorabiliaContext, MemorabiliaContext>();
            services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
            services.AddTransient<IDomainContext, DomainContext>();
            services.AddTransient<CommandRouter>();
            services.AddTransient<QueryRouter>();

            services.AddMediatR(typeof(GetAccomplishments).Assembly);

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

            services.AddTransient<IAcquisitionTypeRepository, AcquisitionTypeRepository>();
            services.AddTransient<IAccomplishmentTypeRepository, AccomplishmentTypeRepository>();
            services.AddTransient<IAuthenticationCompanyRepository, AuthenticationCompanyRepository>();            
            services.AddTransient<IAutographRepository, AutographRepository>();
            services.AddTransient<IAwardTypeRepository, AwardTypeRepository>();
            services.AddTransient<IBammerTypeRepository, BammerTypeRepository>();
            services.AddTransient<IBaseballTypeRepository, BaseballTypeRepository>();
            services.AddTransient<IBasketballTypeRepository, BasketballTypeRepository>();
            services.AddTransient<IBatTypeRepository, BatTypeRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();            
            services.AddTransient<IChampionTypeRepository, ChampionTypeRepository>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<ICommissionerRepository, CommissionerRepository>();
            services.AddTransient<IConditionRepository, ConditionRepository>();
            services.AddTransient<IConferenceRepository, ConferenceRepository>();
            services.AddTransient<IDashboardItemRepository, DashboardItemRepository>();
            services.AddTransient<IDivisionRepository, DivisionRepository>();
            services.AddTransient<IFigureSpecialtyTypeRepository, FigureSpecialtyTypeRepository>();
            services.AddTransient<IFigureTypeRepository, FigureTypeRepository>();
            services.AddTransient<IFootballTypeRepository, FootballTypeRepository>();
            services.AddTransient<IFranchiseRepository, FranchiseRepository>();
            services.AddTransient<IFranchiseHallOfFameTypeRepository, FranchiseHallOfFameTypeRepository>();
            services.AddTransient<IGameStyleTypeRepository, GameStyleTypeRepository>();
            services.AddTransient<IGloveTypeRepository, GloveTypeRepository>();
            services.AddTransient<IHallOfFameRepository, HallOfFameRepository>();
            services.AddTransient<IHelmetFinishRepository, HelmetFinishRepository>();
            services.AddTransient<IHelmetQualityTypeRepository, HelmetQualityTypeRepository>();
            services.AddTransient<IHelmetTypeRepository, HelmetTypeRepository>();
            services.AddTransient<IImageTypeRepository, ImageTypeRepository>();
            services.AddTransient<IInscriptionTypeRepository, InscriptionTypeRepository>();                      
            services.AddTransient<IInternationalHallOfFameTypeRepository, InternationalHallOfFameTypeRepository>();                      
            services.AddTransient<IItemTypeBrandRepository, ItemTypeBrandRepository>();
            services.AddTransient<IItemTypeGameStyleTypeRepository, ItemTypeGameStyleTypeRepository>();
            services.AddTransient<IItemTypeLevelRepository, ItemTypeLevelRepository>();
            services.AddTransient<IItemTypeRepository, ItemTypeRepository>();
            services.AddTransient<IItemTypeSizeRepository, ItemTypeSizeRepository>();
            services.AddTransient<IItemTypeSportRepository, ItemTypeSportRepository>();
            services.AddTransient<IItemTypeSpotRepository, ItemTypeSpotRepository>();           
            services.AddTransient<IJerseyQualityTypeRepository, JerseyQualityTypeRepository>();
            services.AddTransient<IJerseyStyleTypeRepository, JerseyStyleTypeRepository>();
            services.AddTransient<IJerseyTypeRepository, JerseyTypeRepository>();
            services.AddTransient<ILeaderTypeRepository, LeaderTypeRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<ILevelTypeRepository, LevelTypeRepository>();
            services.AddTransient<IMagazineTypeRepository, MagazineTypeRepository>();
            services.AddTransient<IMemorabiliaImageRepository, MemorabiliaImageRepository>();
            services.AddTransient<IMemorabiliaRepository, MemorabiliaRepository>();
            services.AddTransient<IOccupationRepository, OccupationRepository>();
            services.AddTransient<IOrientationRepository, OrientationRepository>();
            services.AddTransient<IPersonAccomplishmentRepository, PersonAccomplishmentRepository>();
            services.AddTransient<IPersonAwardRepository, PersonAwardRepository>();
            services.AddTransient<IPersonNicknameRepository, PersonNicknameRepository>();
            services.AddTransient<IPersonOccupationRepository, PersonOccupationRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonTeamRepository, PersonTeamRepository>();
            services.AddTransient<IPewterRepository, PewterRepository>();
            services.AddTransient<IPhotoTypeRepository, PhotoTypeRepository>();
            services.AddTransient<IPriorityTypeRepository, PriorityTypeRepository>();
            services.AddTransient<IPrivacyTypeRepository, PrivacyTypeRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IPurchaseTypeRepository, PurchaseTypeRepository>();
            services.AddTransient<IRecordTypeRepository, RecordTypeRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
            services.AddTransient<ISportLeagueLevelRepository, SportLeagueLevelRepository>();
            services.AddTransient<ISportRepository, SportRepository>();
            services.AddTransient<ISportServiceRepository, SportServiceRepository>();
            services.AddTransient<ISpotRepository, SpotRepository>();
            services.AddTransient<ITeamChampionshipRepository, TeamChampionshipRepository>();
            services.AddTransient<ITeamConferenceRepository, TeamConferenceRepository>();
            services.AddTransient<ITeamDivisionRepository, TeamDivisionRepository>();
            services.AddTransient<ITeamLeagueRepository, TeamLeagueRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamRoleTypeRepository, TeamRoleTypeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWritingInstrumentRepository, WritingInstrumentRepository>();

            services.AddTransient<IDashboardItemFactory, DashboardItemFactory>();
            services.AddTransient<IProfileRuleFactory, ProfileRuleFactory>();
            services.AddTransient<IProfileService, ProfileService>();
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
    }
}
