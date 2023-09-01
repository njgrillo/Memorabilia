namespace Memorabilia.Blazor.Pages.Autograph;

public partial class ViewAutographImagesFab
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public int AutographId { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }

    public async Task ViewImages()
    {
        var parameters = new DialogParameters
        {
            ["AutographId"] = AutographId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AutographImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }
}
