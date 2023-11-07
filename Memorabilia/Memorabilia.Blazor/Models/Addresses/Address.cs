namespace Memorabilia.Blazor.Models.Addresses;

public class Address : IWithName
{
    public Address() { }

    public Address(Entity.Address address)
    {
        AddressLine1 = address.AddressLine1;
        AddressLine2 = address.AddressLine2;
        City = address.City;
        CountryRegion = address.Country;
        Id = address.Id;
        PostalCode = address.PostalCode;
        StateProvidence = address.StateProvidence;
    }

    public Address(string addressLine1,
                   string addressLine2,
                   string city,
                   string country,
                   int id,
                   string postalCode,
                   string stateProvidence)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        CountryRegion = country;
        Id = id;
        PostalCode = postalCode;
        StateProvidence = stateProvidence;
    }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }    

    public string City { get; set; }

    public string CountryRegion { get; set; }

    public int Id { get; set; }

    public string Name
        => SingleLineAddress;

    public string PostalCode { get; set; }

    public string SingleLineAddress
    {
        get
        {
            string address = AddressLine1;

            if (!AddressLine2.IsNullOrEmpty())
                address += " " + AddressLine2;

            address += " " + $"{City} {StateProvidence} {PostalCode} {CountryRegion}";

            return address;
        }
    }        

    public string StateProvidence { get; set; }    
}
