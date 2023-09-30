namespace Memorabilia.Web.Extensions;

public static class PaymentServiceCollectionExtensions
{
    private static IConfiguration _configuration;

    public static void AddPayments(this IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;

        AddPaypal(services);
        AddStripe(services);
    }

    private static void AddPaypal(IServiceCollection services)
    {
        var paypalSettings = new PaypalSettings();
        _configuration.GetSection("Paypal").Bind(paypalSettings);

        services.AddSingleton<IPaypalSettings>(paypalSettings);

        services.AddSingleton<IPaypalClient, PaypalClient>();
        services.AddScoped<PaypalService>();
    }

    private static void AddStripe(IServiceCollection services)
    {
        var stripeSettings = new StripeSettings();
        _configuration.GetSection("Stripe").Bind(stripeSettings);

        services.AddSingleton<IStripeSettings>(stripeSettings);
        services.AddScoped<StripeService>();
    }
}
