namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class PrivateSigningItemGroup
{
    [Parameter]
    public PrivateSigningItemTypeGroupModel PrivateSigningItemTypeGroup { get; set; }
        = new();
}
