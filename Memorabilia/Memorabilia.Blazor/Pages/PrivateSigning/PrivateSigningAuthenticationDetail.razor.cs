namespace Memorabilia.Blazor.Pages.PrivateSigning;

public partial class PrivateSigningAuthenticationDetail
{
    [Parameter]
    public PrivateSigningAuthenticationCompanyModel PrivateSigningAuthenticationCompany { get; set; }
        = new();
}
