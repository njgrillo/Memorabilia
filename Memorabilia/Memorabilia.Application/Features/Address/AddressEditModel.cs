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
        Id = address.Id;
        PostalCode = address.PostalCode;
        StateProvidence = address.StateProvidence;
    }

    public AddressEditModel(AddressModel address)
    {
        AddressLine1 = address.AddressLine1;
        AddressLine2 = address.AddressLine2;
        City = address.City;
        Country = address.Country;
        Id = address.Id;
        PostalCode = address.PostalCode;
        StateProvidence = address.StateProvidence;
    }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public override string Name
        => SingleLine;

    public string PostalCode { get; set; }

    public string SingleLine
    {
        get
        {
            string address = AddressLine1;

            if (!AddressLine2.IsNullOrEmpty())
                address += " " + AddressLine2;

            address += " " + $"{City} {StateProvidence} {PostalCode} {Country}";

            return address;
        }
    }

    public string StateProvidence { get; set; }
}
