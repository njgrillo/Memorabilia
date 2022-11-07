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
            services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
            services.AddTransient<CommandRouter>();
            services.AddTransient<QueryRouter>();
            services.AddMediatR(typeof(GetAccomplishments).Assembly);

            //services.AddScoped<PersonRepository>();
            //services.AddScoped<IPersonRepository, PersonCacheRepository>();

            //services.AddScoped<AllStarRepository>();
            //services.AddScoped<IAllStarRepository, AllStarCacheRepository>();

            //services.AddScoped<CareerRecordRepository>();
            //services.AddScoped<ICareerRecordRepository, CareerRecordCacheRepository>();

            //services.AddScoped<ChampionRepository>();
            //services.AddScoped<IChampionRepository, ChampionCacheRepository>();

            //services.AddScoped<DraftRepository>();
            //services.AddScoped<IDraftRepository, DraftCacheRepository>();

            //services.AddScoped<FranchiseHallOfFameRepository>();
            //services.AddScoped<IFranchiseHallOfFameRepository, FranchiseHallOfFameCacheRepository>();

            //services.AddScoped<HallOfFameRepository>();
            //services.AddScoped<IHallOfFameRepository, HallOfFameCacheRepository>();

            //services.AddScoped<InternationalHallOfFameRepository>();
            //services.AddScoped<IInternationalHallOfFameRepository, InternationalHallOfFameCacheRepository>();

            //services.AddScoped<LeaderRepository>();
            //services.AddScoped<ILeaderRepository, LeaderCacheRepository>();

            //services.AddScoped<PersonAccomplishmentRepository>();
            //services.AddScoped<IPersonAccomplishmentRepository, PersonAccomplishmentCacheRepository>();

            //services.AddScoped<PersonAwardRepository>();
            //services.AddScoped<IPersonAwardRepository, PersonAwardCacheRepository>();

            //services.AddScoped<PersonCollegeRepository>();
            //services.AddScoped<IPersonCollegeRepository, PersonCollegeCacheRepository>();

            //services.AddScoped<PersonTeamRepository>();
            //services.AddScoped<IPersonTeamRepository, PersonTeamCacheRepository>();

            //services.AddScoped<RetiredNumberRepository>();
            //services.AddScoped<IRetiredNumberRepository, RetiredNumberCacheRepository>();

            //services.AddScoped<SingleSeasonRecordRepository>();
            //services.AddScoped<ISingleSeasonRecordRepository, SingleSeasonRecordCacheRepository>();

            services.AddScoped<MemorabiliaItemRepository>();
            services.AddScoped<IMemorabiliaItemRepository, MemorabiliaItemCacheRepository>();

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
}
