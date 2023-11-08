namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ThroughTheMailAddress
{
    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public AddressEditModel SelectedAddress { get; set; }
        = new();

    private bool _editAddress;
}
