namespace Memorabilia.Web.Extensions;

public static class SharedServiceExtensions
{
    private static IConfiguration _configuration;

    public static void AddShared(this IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;

        AddSiteSettings(services);
    }

    private static void AddSiteSettings(IServiceCollection services)
    {
        var siteSettings = new SiteSettings();
        _configuration.GetSection("SiteSettings").Bind(siteSettings);

        services.AddSingleton<ISiteSettings>(siteSettings);
    }
}
