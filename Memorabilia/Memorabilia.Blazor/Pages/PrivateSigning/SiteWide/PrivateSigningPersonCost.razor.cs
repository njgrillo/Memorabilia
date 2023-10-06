namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class PrivateSigningPersonCost
{
    [Parameter]
    public PrivateSigningPersonDetailModel[] PrivateSigningPersonDetails { get; set; }
        = Array.Empty<PrivateSigningPersonDetailModel>();
}
