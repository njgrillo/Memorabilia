namespace Memorabilia.Application.Features.Address;

public class AddressEditModel : EditModel
{
    public AddressEditModel() { }

    public AddressEditModel(Entity.Address address) 
    {
        AddressLine1 = address.AddressLine1;
        AddressLine2 = address.AddressLine2;
        City = address.City;
        Country = address.Country;
        PostalCode = address.PostalCode;
        SingleLine = address.SingleLine;
        StateProvidence = address.StateProvidence;
    }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public string PostalCode { get; set; }

    public string SingleLine { get; set; }

    public string StateProvidence { get; set; }
}
