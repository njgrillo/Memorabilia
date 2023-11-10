namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaItemGallerySubCard
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string EditNavigationPath { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public string ImageNavigationPath { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    protected void OnEditClick()
    {
        NavigationManager.NavigateTo(EditNavigationPath);
    }

    protected async Task OnImageClick()
    {
        await ShowPersonProfileDialog();
    }

    protected async Task ShowPersonProfileDialog()
    {
        if (PersonId == 0)
            return;

        var parameters = new DialogParameters
        {
            ["PersonId"] = PersonId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }
}
