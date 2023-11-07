namespace Memorabilia.Blazor.Controls.Addresses;

public partial class MultiLineAddress
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Parameter]
    public Models.Addresses.Address SelectedAddress { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        await JSRuntime.InitializeMultiLineAddressAutocomplete();
    }
}
