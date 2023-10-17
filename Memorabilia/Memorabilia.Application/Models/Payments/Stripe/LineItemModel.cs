namespace Memorabilia.Application.Models.Payments.Stripe;

public class LineItemModel
{
	public LineItemModel() { }

    public LineItemModel(int amount,
                         int quantity)
    {
        Amount = amount;
        Quantity = quantity;
    }

    public int Amount { get; set; }

    public string Currency { get; set; }
        = "usd";

    public ProductModel Product { get; set; }
        = new();

    public int Quantity { get; set; }

    public RecurringModel Recurring { get; set; }

    public void SetCurrency(string currency)
    {
        Currency = currency;
    }

    public void SetProduct(ProductModel product)
    {
        Product = product;
    }

    public void SetRecurring(RecurringModel recurring)
    {
        Recurring = recurring;
    }
}
