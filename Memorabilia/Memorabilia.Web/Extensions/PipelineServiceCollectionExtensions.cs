namespace Memorabilia.Web.Extensions;

public static class PipelineServiceCollectionExtensions
{
    public static void AddPipelines(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
    }
}
