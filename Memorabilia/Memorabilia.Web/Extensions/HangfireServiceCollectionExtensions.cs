using Memorabilia.Application.Services.Hangfire;

namespace Memorabilia.Web.Extensions;

public static class HangfireServiceCollectionExtensions
{
    public static void ConfigureHangfire(this IServiceCollection services,
                                         IConfiguration configuration)
    {
        string connecitonString = configuration.GetConnectionString("Memorabilia");

        services.AddHangfire(configuration =>
            configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                         .UseSimpleAssemblyNameTypeSerializer()
                         .UseRecommendedSerializerSettings()
                         .UseSqlServerStorage(
                            connecitonString,
                            new Hangfire.SqlServer.SqlServerStorageOptions
                            {
                                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                                QueuePollInterval = TimeSpan.Zero,
                                UseRecommendedIsolationLevel = true,
                                DisableGlobalLocks = true
                            }))
                .AddHangfireServer()
                .AddOptions()
                .AddJobs(configuration);

        services.AddHostedService<HangfireService>();
    }

    private static IServiceCollection AddJobs(this IServiceCollection services,
                                              IConfiguration config)
    {
        IConfigurationSection jobConfig = config.GetSection("HangfireJobOptions");

        List<Type> jobTypes = typeof(HangfireJobAttribute).GetTypeInfo().Assembly
                                                          .GetTypes()
                                                          .Where(type => !type.IsAbstract)
                                                          .Where(type => type.GetCustomAttributes(typeof(HangfireJobAttribute), true).Length > 0)
                                                          .ToList();

        foreach (Type jobType in jobTypes)
        {
            Type jobOptionType = jobType.BaseType!.GetGenericArguments().First();

            var parameterTypes = new Type[]
            {
                    typeof(IServiceCollection),
                    typeof(IConfigurationSection)
            };

            MethodInfo addJobServiceMethodInfo
                = typeof(HangfireServiceCollectionExtensions).GetMethod(nameof(AddJobService),
                                                                        BindingFlags.Static | BindingFlags.NonPublic,
                                                                        parameterTypes)!;

            MethodInfo addJobServiceGenericMethodInfo
                = addJobServiceMethodInfo.MakeGenericMethod(jobType, jobOptionType);

            addJobServiceGenericMethodInfo.Invoke(obj: null, parameters: new object[] { services, jobConfig });
        }

        return services;
    }

    private static void AddJobService<TJob, TJobOption>(IServiceCollection services,
                                                        IConfigurationSection jobOptionSection)
        where TJob : HangfireJob<TJobOption>
        where TJobOption : HangfireJobOption<TJobOption>
    {
        IConfigurationSection jobOption = jobOptionSection.GetSection(typeof(TJobOption).Name);

        services.AddTransient<TJob>().Configure<TJobOption>(jobOption);
    }
}
