var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutofac();
builder.Services.AddDataProtection()
                .SetApplicationName("Memorabilia")
                .SetDefaultKeyLifetime(TimeSpan.FromDays(180));

builder.Services.AddCourier(typeof(GetCommissioner).Assembly);

builder.Services.AddShared(builder.Configuration);
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddPayments(builder.Configuration);
builder.Services.ConfigureHangfire(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new RepositoryModule());
                builder.RegisterModule(new ApplicationModule());
            });

builder.Services.AddAuthenticationCore();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<MemorabiliaContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
builder.Services.AddDbContext<DomainContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
builder.Services.AddDbContext<HistoryContext>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"), ServiceLifetime.Transient);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCommissioner).Assembly));
builder.Services.AddDataProtection();
builder.Services.RegisterValidators();
builder.Services.RegisterFactories();
builder.Services.RegisterServices();
builder.Services.RegisterCachedRepositories();
builder.Services.AddPipelines();
builder.Services.AddServices(builder.Configuration);

builder.Services.AddServerSideBlazor()
                .AddHubOptions(opt =>
                {
                    opt.DisableImplicitFromServicesParameters = true;
                });

builder.Services.AddMudServices(config =>
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

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//TODO
//app.MapFallbackToFile("index.html");

app.Run();
