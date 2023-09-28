namespace Memorabilia.Blazor.Pages.SignatureReview;

public partial class AddSignatureReview
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public ILogger<AddSignatureReview> Logger { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public SignatureReviewValidator Validator { get; set; }

    protected SignatureReviewEditModel EditModel { get; set; }
        = new();

    protected List<ImageEditModel> Images { get; set; }
        = new();

    protected Alert[] ValidationResultAlerts
       => EditModel.ValidationResult.Errors?.Any() ?? false
           ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
           : Array.Empty<Alert>();

    private IReadOnlyList<IBrowserFile> _files;

    protected override void OnInitialized()
    {
        EditModel.CreatedUserId = ApplicationStateService.CurrentUser.Id;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult.IsValid)
            return;

        await JSRuntime.ScrollToAlert();
    }

    protected async Task LoadFiles(InputFileChangeEventArgs e)
    {
        _files = e.GetMultipleFiles(3);

        EditModel.Images.Clear();

        foreach (IBrowserFile file in _files)
        {
            try
            {
                string fileName = await ImageService.LoadFile(file, Enum.ImageRootType.User);

                EditModel.Images.Add(new SignatureReviewImageEditModel(fileName));
            }
            catch (Exception ex)
            {
                Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
            }
        }
    }

    protected async Task OnSave()
    {
        var command = new SaveSignatureReview.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Signature Review was added successfully!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.SignatureReview);
    }
}
