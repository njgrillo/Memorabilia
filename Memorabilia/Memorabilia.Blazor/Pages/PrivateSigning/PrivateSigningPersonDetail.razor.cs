namespace Memorabilia.Blazor.Pages.PrivateSigning;

public partial class PrivateSigningPersonDetail
{
    [Parameter]
    public PrivateSigningPersonModel PrivateSigningPerson { get; set; }
        = new();
}
