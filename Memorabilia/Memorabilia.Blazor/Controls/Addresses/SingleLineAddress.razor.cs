namespace Memorabilia.Blazor.Controls.Addresses;

public partial class SingleLineAddress
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Parameter]
    public int MaxLength { get; set; }
        = 250;

    [Parameter]
    public string SelectedAddress { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        await JSRuntime.InitializeSingleLineAddressAutocomplete();
    }
}
