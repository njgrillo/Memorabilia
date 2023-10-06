namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class PrivateSigningDetail
{
    [Parameter]
    public PrivateSigningModel PrivateSigning { get; set; }
        = new();
}
