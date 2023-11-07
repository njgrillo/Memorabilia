namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ThroughTheMailAddress
{
    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public Models.Addresses.Address SelectedAddress { get; set; }
        = new();

    private bool _newAddressSelected;
}
