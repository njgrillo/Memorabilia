namespace Memorabilia.Blazor.Models.Paypal;

public class PaypalUserModel
{
	public PaypalUserModel() { }

	public PaypalUserModel(string emailAddress,
						   string firstName,
						   string lastName)
	{
		EmailAddress = emailAddress;
        FirstName = firstName;
        LastName = lastName;
	}

	public string EmailAddress { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }
}
