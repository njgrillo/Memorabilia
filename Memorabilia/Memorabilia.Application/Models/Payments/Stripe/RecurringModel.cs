namespace Memorabilia.Application.Models.Payments.Stripe;

public class RecurringModel
{
    public RecurringModel() { }

    public RecurringModel(string interval, int intervalCount)
    {
        Interval = interval;
        IntervalCount = intervalCount;
    }

    public string Interval { get; set; }

    public int IntervalCount { get; set; }
}
