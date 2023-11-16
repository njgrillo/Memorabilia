using Memorabilia.Application.Services.Interfaces;
using Memorabilia.Application.Services.Security;

namespace Memorabilia.Web.Extensions;

public static class ServiceCollectionExtensions
{
    private static IConfiguration _configuration;

    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;

        AddDataProtection(services);
        AddEmail(services);
        AddImages(services);

        services.AddSingleton<HelpItemIconService>();
    }

    private static void AddDataProtection(IServiceCollection services)
    {
        var developerSettings = new DeveloperSettings();
        _configuration.GetSection("DeveloperSettings").Bind(developerSettings);

        if (!developerSettings.EncryptIds)
        {
            services.AddScoped<IDataProtectorService, DataProtectorDebugService>();
        }
        else
        {
            services.AddScoped<IDataProtectorService, DataProtectorService>();
        }
    }

    private static void AddEmail(IServiceCollection services)
    {
        var emailSettings = new EmailSettings();
        _configuration.GetSection("EmailSettings").Bind(emailSettings);

        services.AddSingleton<IEmailSettings>(emailSettings);
        services.AddSingleton<EmailService>();
    }

    private static void AddImages(IServiceCollection services)
    {
        var imagePath = new ImagePath();
        _configuration.GetSection("ImagePaths").Bind(imagePath);

        services.AddSingleton<IImagePath>(imagePath);
        services.AddSingleton<ImageService>();
    }
}
