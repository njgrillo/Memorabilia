namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Images;

public partial class MemorabiliaImageEditor : ImagePage
{
    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private EditImages<SaveMemorabiliaImagesViewModel> EditImages;
    private SaveMemorabiliaImagesViewModel ViewModel = new ();

    protected async Task OnLoad()
    {
        ViewModel = new SaveMemorabiliaImagesViewModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId)));
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
            //Open Modal
        }   
    }
}
