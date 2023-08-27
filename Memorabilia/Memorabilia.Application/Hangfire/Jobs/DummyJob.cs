namespace Memorabilia.Application.Hangfire.Jobs;

[HangfireJob]
public class DummyJob : HangfireJob<DummyJobOption>
{
	public DummyJob(IOptions<DummyJobOption> options)
		: base(options) { }

    public override Task Process()
    {
        throw new NotImplementedException();
    }

    public override Task DisposeJob()
    {
        throw new NotImplementedException();
    }
}
