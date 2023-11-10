namespace Memorabilia.Domain.Entities;

public class PrivateSigningAuthenticationCompany : Entity
{
    public PrivateSigningAuthenticationCompany() { }

    public PrivateSigningAuthenticationCompany(int authenticationCompanyId,
                                               decimal cost,
                                               int privateSigningId)
    {
        AuthenticationCompanyId = authenticationCompanyId;
        Cost = cost;
        PrivateSigningId = privateSigningId;
    }

    public int AuthenticationCompanyId { get; private set; }

    public decimal Cost { get; private set; }

    public virtual PrivateSigning PrivateSigning { get; private set; }

    public int PrivateSigningId { get; private set; }

    public void Set(decimal cost)
    {
        Cost = cost;
    }
}
