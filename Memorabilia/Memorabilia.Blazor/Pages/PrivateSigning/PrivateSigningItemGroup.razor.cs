namespace Memorabilia.Blazor.Pages.PrivateSigning;

public partial class PrivateSigningItemGroup
{
    [Parameter]
    public PrivateSigningItemTypeGroupModel PrivateSigningItemTypeGroup { get; set; }
        = new();
}
