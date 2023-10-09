namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PrivateSigningEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public PrivateSigningValidator Validator { get; set; }

    [Parameter]
    public string EncryptPrivateSigningId { get; set; }

    protected PrivateSigningEditModel EditModel { get; set; }
        = new();

    protected int PrivateSigningId { get; set; }

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
            = await QueryRouter.Send(new GetPrivateSigning(PrivateSigningId));

        EditModel = new(privateSigning);
    }

    protected async Task OnSave()
    {
        var command = new SavePrivateSigning.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Private Signing was saved successfully!", Severity.Success);
    }
}
