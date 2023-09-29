namespace Memorabilia.Blazor.Pages.PrivateSigning;

public partial class PrivateSigningPersonDetail
{
    [Parameter]
    public ImageService ImageService { get; set; }

    [Parameter]
    public PrivateSigningPersonModel PrivateSigningPerson { get; set; }
        = new();
}
