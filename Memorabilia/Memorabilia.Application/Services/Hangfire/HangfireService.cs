namespace Memorabilia.Application.Services.Hangfire;

public class HangfireService(IServiceProvider serviceProvider)
    : IHangfireService, IHostedService, IDisposable
{
    private BackgroundJobServer _backgroundJobServer;

    public void Dispose()
        => _backgroundJobServer?.Dispose();

    public Task StartAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return Task.FromCanceled(cancellationToken);

        _backgroundJobServer = new BackgroundJobServer();

        ConfigureHangfireJobs();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _backgroundJobServer.Dispose();

        return Task.CompletedTask;
    }

    private void ConfigureHangfireJobs()
    {
        Type[] jobTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(type => !type.IsAbstract)
                                  .Where(type => type.GetCustomAttributes(typeof(HangfireJobAttribute), true).Length > 0)
                                  .ToArray();

        foreach (Type jobType in jobTypes)
        {
            Type jobOptionType = jobType.BaseType!
                                        .GetGenericArguments()
                                        .First();

            MethodInfo configureJobMethodInfo
                = GetType().GetMethod(nameof(ConfigureJob), BindingFlags.Instance | BindingFlags.NonPublic)!;

            MethodInfo configureJobGenericMethodInfo
                = configureJobMethodInfo.MakeGenericMethod(jobType, jobOptionType);

            configureJobGenericMethodInfo.Invoke(obj: this, parameters: []);
        }
    }

    private void ConfigureJob<TJob, TJobOption>()
        where TJob : HangfireJob<TJobOption>
        where TJobOption : HangfireJobOption<TJobOption>
    {
        TJobOption jobOption = serviceProvider.GetRequiredService<IOptions<TJobOption>>().Value;

        if (jobOption.Enabled)
        {
            var options = new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            };

            RecurringJob.AddOrUpdate<TJob>(jobOption.HangfireJobId,
                                           job => job.Process(),
                                           jobOption.ScheduleCronExpression,
                                           options);
        }
        else
        {
            RecurringJob.RemoveIfExists(jobOption.HangfireJobId);
        }
    }
}
