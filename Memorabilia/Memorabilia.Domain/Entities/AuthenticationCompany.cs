namespace Memorabilia.Domain.Entities;

public class AuthenticationCompany : DomainEntity
{
    public AuthenticationCompany() { }

    public AuthenticationCompany(string name, string abbreviation) : base(name, abbreviation) { }
}
