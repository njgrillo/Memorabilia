namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailAddressModel
{
    private readonly Entity.Address _address;

    public ThroughTheMailAddressModel() { }

    public ThroughTheMailAddressModel(Entity.Address address)
    {
        _address = address;       
    }

    public string AddressLine1
        => _address?.AddressLine1;

    public string AddressLine2
        => _address?.AddressLine2;

    public string City
        => _address?.City;

    public string Country
        => _address?.Country;

    public int Id 
        => _address?.Id ?? 0;

    public string PostalCode
        => _address?.PostalCode;

    public string StateProvidence
        => _address?.StateProvidence;
}
