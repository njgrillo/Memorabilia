namespace Memorabilia.Web.Extensions;

public static class AuthenticationServiceCollectionExtensions
{
    public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var cookieConfiguration = new CookieConfiguration();
        configuration.GetSection("Cookie").Bind(cookieConfiguration);

        var facebookConfiguration = new FacebookConfiguration();
        configuration.GetSection("Facebook").Bind(facebookConfiguration);

        var googleConfiguration = new GoogleConfiguration();
        configuration.GetSection("Google").Bind(googleConfiguration);

        var microsoftConfiguration = new MicrosoftConfiguration();
        configuration.GetSection("Microsoft").Bind(microsoftConfiguration);

        var xConfiguration = new XConfiguration();
        configuration.GetSection("X").Bind(xConfiguration);

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddFacebook(options =>
                {
                    options.ClientId = facebookConfiguration.ClientId;
                    options.ClientSecret = facebookConfiguration.ClientSecret;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = googleConfiguration.ClientId;
                    options.ClientSecret = googleConfiguration.ClientSecret;
                    options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                    options.ClaimActions.MapJsonKey("urn:google:image", "picture");
                })
                .AddMicrosoftAccount(options =>
                {
                    options.ClientId = microsoftConfiguration.ClientId;
                    options.ClientSecret = microsoftConfiguration.ClientSecret;
                })
                .AddTwitter(options =>
                {
                    options.ConsumerKey = xConfiguration.ConsumerAPIKey;
                    options.ConsumerSecret = xConfiguration.ConsumerSecret;
                })
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan= TimeSpan.FromDays(cookieConfiguration.CookieRetentionDays);
                });

        services.AddScoped<ILoginProviderRuleFactory, LoginProviderRuleFactory>();
        services.AddSingleton<LoginProviderService>();
    }
}
