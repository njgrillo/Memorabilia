namespace Memorabilia.Domain.Entities;

public class Address : Entity
{
	public Address() { }

    public Address(string addressLine1,
                   string addressLine2,
                   string city,
                   string country,
                   string postalCode,
                   string singleLine,
                   string stateProvidence)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        Country = country;
        PostalCode = postalCode;
        SingleLine = singleLine;
        StateProvidence = stateProvidence;
    }

    public string AddressLine1 { get; private set; }

	public string AddressLine2 { get; private set; }

	public string City { get; private set; }

	public string Country { get; private set; }

	public string PostalCode { get; private set; }

	public string SingleLine { get; private set; }

    public string StateProvidence { get; private set; }

    public void Set(string addressLine1,
                    string addressLine2,
                    string city,
                    string country,
                    string postalCode,
                    string singleLine,
                    string stateProvidence)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        Country = country;
        PostalCode = postalCode;
        SingleLine = singleLine;
        StateProvidence = stateProvidence;
    }
}
