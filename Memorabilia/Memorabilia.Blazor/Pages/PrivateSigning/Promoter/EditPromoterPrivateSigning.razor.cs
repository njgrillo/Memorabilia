namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigning
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public ILogger<EditPromoterPrivateSigning> Logger { get; set; }

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

    public string StartSigningDateLabelText
        => EditModel.MultiDaySigning
            ? "Start Date"
            : "Signing Date";

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.HasErrors()
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];

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

    protected void OnMarkAsCompleteClick()
    {
        foreach (PrivateSigningPersonEditModel person in EditModel.People)
        {
            person.StatusId = PrivateSigningStatus.Completed.Id;
        }
    }

    protected void OnMultiDaySigningChanged(bool multiDaySigning)
    {
        EditModel.MultiDaySigning = multiDaySigning;

        if (multiDaySigning)
            return;

        EditModel.EndSigningDate = null;
    }    

    protected async Task OnPromotionalImageClick()
    {
        var parameters = new DialogParameters
        {
            ["ImageFileName"] = EditModel.PromoterImageFileName,
            ["UserId"] = ApplicationStateService.CurrentUser.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImageDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    private async Task OnPublishClick()
    {
        var dialog = DialogService.Show<PublishDialog>();
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Mediator.Send(new PublishPrivateSigning(EditModel.Id));

        Snackbar.Add("Private Signing was published successfully!", Severity.Success);

        Entity.PrivateSigning privateSigning
            = await Mediator.Send(new GetPrivateSigning(EditModel.Id));

        EditModel = new(privateSigning);
    }

    protected async Task OnSave(bool publish)
    {
        EditModel.Published = publish;

        if (publish)
            EditModel.PublishedDate = DateTime.UtcNow;

        var command = new SavePrivateSigning.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        string message = EditModel.Published
            ? "Private Signing was saved & published successfully!"
            : "Private Signing was saved successfully!";

        Snackbar.Add(message, Severity.Success);

        Entity.PrivateSigning privateSigning
            = await Mediator.Send(new GetPrivateSigning(EditModel.Id));

        EditModel = new(privateSigning);
    }

    protected void RemovePromoterImage()
    {
        EditModel.PromoterImageFileName = null;
    }
}
