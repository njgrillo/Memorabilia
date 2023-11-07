namespace Memorabilia.Blazor.Models.Addresses;

public class Address
{
    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }    

    public string City { get; set; }

    public string CountryRegion { get; set; }

    public string PostalCode { get; set; }

    public string SingleLineAddress1
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
