namespace Memorabilia.Application.Models.Payments.Stripe;

public class PriceModel
{
	public PriceModel() { }

    public int Amount { get; set; }

    public string Id { get; set; }

	public RecurringModel Recurring { get; set; }
		= new();
}
