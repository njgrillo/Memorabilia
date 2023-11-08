namespace Memorabilia.Application.Features.Address;

public class AddressModel: IWithName
{
    private readonly Entity.Address _address;

    public AddressModel() { }

    public AddressModel(Entity.Address address)
    {
        _address = address;  
    }

    public string AddressLine1
        => _address.AddressLine1;

    public string AddressLine2
        => _address.AddressLine2;

    public string City
        => _address.City;

    public string Country
        => _address.Country;

    public int Id 
        => _address.Id;

    public string Name
        => SingleLine;

    public string PostalCode
        => _address.PostalCode;

    public string SingleLine
        => _address.SingleLine;

    public string StateProvidence
        => _address.StateProvidence;
}
