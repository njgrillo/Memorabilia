namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailAddressEditModel : EditModel
{
    public ThroughTheMailAddressEditModel() { }

    public ThroughTheMailAddressEditModel(Entity.Address address)
    {
        AddressLine1 = address.AddressLine1;
        AddressLine2 = address.AddressLine2;
        City = address.City;
        Country = address.Country;
        PostalCode = address.PostalCode;
        StateProvidence = address.StateProvidence;
    }

    public ThroughTheMailAddressEditModel(ThroughTheMailAddressModel address)
    {
        AddressLine1 = address.AddressLine1;
        AddressLine2 = address.AddressLine2;
        City = address.City;
        Country = address.Country;
        PostalCode = address.PostalCode;
        StateProvidence = address.StateProvidence;
    }

    public ThroughTheMailAddressEditModel(string addressLine1,
                                          string addressLine2,
                                          string city,
                                          string country,
                                          string postalCode,
                                          string stateProvidence)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        Country = country;
        PostalCode = postalCode;
        StateProvidence = stateProvidence;
    }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public string PostalCode { get; set; }

    public string StateProvidence { get; set; }
}
