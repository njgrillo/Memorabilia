namespace Memorabilia.Blazor.Pages.PrivateSigning;

public partial class PrivateSigningDetail
{
    [Parameter]
    public PrivateSigningModel PrivateSigning { get; set; }
        = new();
}
