namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class ViewMemorabiliaImagesFab
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }

    public async Task ViewImages()
    {
        var parameters = new DialogParameters
        {
            ["MemorabiliaId"] = MemorabiliaId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<MemorabiliaImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }
}
