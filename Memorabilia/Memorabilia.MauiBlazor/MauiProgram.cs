﻿namespace Memorabilia.MauiBlazor;

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
        builder.Services.AddMediatR(typeof(GetAccomplishments).Assembly);

        builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

        var autofacBuilder = new ContainerBuilder();
        autofacBuilder.Populate(builder.Services);

        autofacBuilder.RegisterModule(new RepositoryModule());
        autofacBuilder.RegisterModule(new ApplicationModule());

        autofacBuilder.Build();

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