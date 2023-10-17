namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PrivateSigningEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public ILogger<PrivateSigningEditor> Logger { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public PrivateSigningValidator Validator { get; set; }

    [Parameter]
    public string EncryptPrivateSigningId { get; set; }

    protected PrivateSigningEditModel EditModel { get; set; }
        = new();

    protected int PrivateSigningId { get; set; }

    public ImageEditModel PromoterPrivateSigningImage { get; set; }
        = new();

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult.IsValid)
            return;

        await JSRuntime.ScrollToAlert();
    }

    protected override async Task OnInitializedAsync()
    {
        if (EncryptPrivateSigningId.IsNullOrEmpty())
        {
            EditModel = new(ApplicationStateService.CurrentUser);
            return;
        }            

        PrivateSigningId = DataProtectorService.DecryptId(EncryptPrivateSigningId);

        Entity.PrivateSigning privateSigning 
            = await Mediator.Send(new GetPrivateSigning(PrivateSigningId));

        EditModel = new(privateSigning);
    }

    protected async Task LoadFile(InputFileChangeEventArgs e)
    {
        try
        {
            EditModel.PromoterImageFileName
                = await ImageService.LoadFile(e.File, Enum.ImageRootType.User);

            PromoterPrivateSigningImage 
                = new ImageEditModel(new ImageModel(new Entity.Image(EditModel.PromoterImageFileName)));
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", e.File.Name, ex.Message);
        }
    }

    protected void OnPeopleModified()
    {
        StateHasChanged();
    }

    protected async Task OnSave()
    {
        var command = new SavePrivateSigning.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Private Signing was saved successfully!", Severity.Success);
    }

    protected void RemovePromoterImage()
    {
        EditModel.PromoterImageFileName = null;
    }
}
