namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class PrivateSigningAuthenticationDetail
{
    [Parameter]
    public PrivateSigningAuthenticationCompanyModel PrivateSigningAuthenticationCompany { get; set; }
        = new();
}
