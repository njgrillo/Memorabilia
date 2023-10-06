namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class PrivateSigningPersonExcludedItems
{
    [Parameter]
    public PrivateSigningPersonExcludeItemTypeModel[] ExcludedItems { get; set; }
        = Array.Empty<PrivateSigningPersonExcludeItemTypeModel>();
}
