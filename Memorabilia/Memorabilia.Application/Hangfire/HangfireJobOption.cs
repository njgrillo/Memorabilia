namespace Memorabilia.Application.Hangfire;

public abstract class HangfireJobOption<T> : IOptions<T>
    where T : HangfireJobOption<T>
{
    public bool Enabled { get; set; }

    public int ExecutingUserId { get; set; }

    public string HangfireJobId { get; set; }

    public string ScheduleCronExpression { get; set; }
        = "0 0 31 2 *"; //Never (Feb 31st)

    public abstract T Value { get; }
}
