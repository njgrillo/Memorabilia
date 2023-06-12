namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Images;

public partial class MemorabiliaImageEditor
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    [Parameter]
    public int UserId { get; set; }
    
    private EditImages<MemorabiliaImagesEditModel> EditImages;
    private MemorabiliaImagesEditModel ViewModel = new ();

    protected async Task OnLoad()
    {
        ViewModel = new MemorabiliaImagesEditModel(new MemorabiliaModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        ViewModel.Images = EditImages.Images;            

        await CommandRouter.Send(new SaveMemorabiliaImage.Command(ViewModel));
    }

    protected async Task SaveAndAddAutograph()
    {
        await OnSave();

        NavigationManager.NavigateTo(ViewModel.ContinueNavigationPath);
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task SaveAndAddItem()
    {
        await OnSave();

        NavigationManager.NavigateTo("/Memorabilia/Edit");
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task SaveAndEditAutograph()
    {
        await OnSave();

        Snackbar.Add("Images were saved successfully!", Severity.Success);

        if (!ViewModel.HasMultipleAutographs)
        {
            NavigationManager.NavigateTo(ViewModel.AutographNavigationPath);
        }
        else
        {
            var parameters = new DialogParameters
            {
                ["MemorabiliaId"] = ViewModel.MemorabiliaId
            };

            var options = new DialogOptions() 
            { 
                MaxWidth = MaxWidth.Large, 
                FullWidth = true, 
                DisableBackdropClick = true
            };

            var dialog = DialogService.Show<SelectAutographDialog>("Select Autograph", parameters, options);
            var result = await dialog.Result;

            if (result.Canceled)
                return;

            _ = int.TryParse(result.Data.ToString(), out int autographId);

            if (autographId == 0)
                return;

            var url = $"Autographs/{EditModeType.Update.Name}/{ViewModel.MemorabiliaId}/{autographId}";

            NavigationManager.NavigateTo(url);
        }   
    }
}
