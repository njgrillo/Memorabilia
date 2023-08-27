namespace Memorabilia.Application.Hangfire.Jobs;

public class DummyJobOption : HangfireJobOption<DummyJobOption>
{
    public override DummyJobOption Value
        => this;
}
