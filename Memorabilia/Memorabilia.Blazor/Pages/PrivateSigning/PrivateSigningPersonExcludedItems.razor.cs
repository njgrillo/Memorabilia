namespace Memorabilia.Blazor.Pages.PrivateSigning;

public partial class PrivateSigningPersonExcludedItems
{
    [Parameter]
    public PrivateSigningPersonExcludeItemTypeModel[] ExcludedItems { get; set; }
        = Array.Empty<PrivateSigningPersonExcludeItemTypeModel>();
}
