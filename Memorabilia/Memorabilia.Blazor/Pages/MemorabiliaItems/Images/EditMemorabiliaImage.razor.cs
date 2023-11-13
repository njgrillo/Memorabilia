namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Images;

public partial class EditMemorabiliaImage
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public string EncryptMemorabiliaId { get; set; }

    protected int MemorabiliaId;

    private EditImages<MemorabiliaImagesEditModel> EditImages;

    private MemorabiliaImagesEditModel EditModel 
        = new ();

    private string _backNavigationPath;
    private string _continueNavigationPath;

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        EditModel 
            = new MemorabiliaImagesEditModel(new MemorabiliaModel(await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId))));

        _backNavigationPath
            = $"{NavigationPath.Memorabilia}/{EditModel.ItemTypeName}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";

        _continueNavigationPath
            = $"{NavigationPath.Autographs}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}/{DataProtectorService.EncryptId(-1)}";
    }

    protected async Task OnSave()
    {
        EditModel.Images = EditImages.Images;            

        await Mediator.Send(new SaveMemorabiliaImage.Command(EditModel));
    }

    protected async Task SaveAndAddAutograph()
    {
        await OnSave();

        NavigationManager.NavigateTo(_continueNavigationPath);

        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task SaveAndAddItem()
    {
        await OnSave();

        NavigationManager.NavigateTo($"/{NavigationPath.Memorabilia}/{EditModeType.Update.Name}");

        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task SaveAndEditAutograph()
    {
        await OnSave();

        Snackbar.Add("Images were saved successfully!", Severity.Success);

        if (!EditModel.HasMultipleAutographs)
        {
            NavigationManager.NavigateTo($"{NavigationPath.Autographs}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}/{(DataProtectorService.EncryptId(EditModel.AutographId.HasValue ? EditModel.AutographId.Value : -1))}");
        }
        else
        {
            var parameters = new DialogParameters
            {
                ["MemorabiliaId"] = EditModel.MemorabiliaId
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

            _ = result.Data.ToString().TryParse(out int autographId);

            if (autographId == 0)
                return;

            string url = $"{NavigationPath.Autographs}/{EditModeType.Update.Name}/{EditModel.MemorabiliaId}/{autographId}";

            NavigationManager.NavigateTo(url);
        }   
    }

    private string GetPageTitle()
        => $"{(EditModel.EditModeType == Constant.EditModeType.Add ? Constant.EditModeType.Add.Name : Constant.EditModeType.Update.Name)} Memorabilia Image(s)";
}
