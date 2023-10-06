namespace Memorabilia.Application.Models.Payments.Stripe;

public class CustomerModel
{
	public CustomerModel() { }

	public CustomerModel(string email, string id, string name)
	{
		Email = email;
		Id = id;
		Name = name;
	}

	public string Email { get; set; }

	public string Id { get; set; }

	public string Name { get; set; }
}
