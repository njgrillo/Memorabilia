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

        var imagePath = new ImagePath();
        Configuration.GetSection("ImagePaths").Bind(imagePath);

        services.AddSingleton<IImagePath>(imagePath);

        var googleConfiguration = new GoogleConfiguration();
        Configuration.GetSection("Google").Bind(googleConfiguration);

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

        services.AddAuthentication()
                .AddGoogle(options =>
                    {
                        options.ClientId = googleConfiguration.ClientId;
                        options.ClientSecret = googleConfiguration.ClientSecret;
                        options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                        options.ClaimActions.MapJsonKey("urn:google:image", "picture");
                    }
                );

        services.AddHttpContextAccessor();
        services.AddScoped<HttpContextAccessor>();
        services.AddHttpClient();
        services.AddScoped<HttpClient>();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddDbContext<MemorabiliaContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
        services.AddTransient<CommandRouter>();
        services.AddTransient<QueryRouter>();
        services.AddMediatR(typeof(GetCommissioner).Assembly);
        services.RegisterValidators();
        services.RegisterFactories();
        services.RegisterServices();
        services.RegisterCachedRepositories();       

        services
            .AddServerSideBlazor()
            .AddHubOptions(opt =>
            {
                opt.DisableImplicitFromServicesParameters = true;
            });

        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
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
        app.UseCookiePolicy();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

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
