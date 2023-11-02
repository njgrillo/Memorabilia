namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class ViewMemorabiliaImagesFab
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public bool CanClick { get; set; }
        = true;

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }

    [Parameter]
    public int? UserId { get; set; }

    public async Task ViewImages()
    {
        if (!CanClick) 
            return;

        var parameters = new DialogParameters
        {
            ["MemorabiliaId"] = MemorabiliaId
        };

        if (UserId.HasValue)
            parameters.Add("UserId", UserId.Value);

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<MemorabiliaImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }
}
