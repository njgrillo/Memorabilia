namespace Memorabilia.Blazor.Pages.Admin.Management.Awards;

public partial class AwardManagementEditor
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public AwardManagementValidator Validator { get; set; }

    [Parameter]
    public int AwardTypeId { get; set; }

    protected AwardManagementEditModel EditModel { get; set; }
        = new();

    protected ValidationResult ValidationResult { get; set; }

    protected Alert[] ValidationResultAlerts
        => ValidationResult != null
        ? ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
        : Array.Empty<Alert>();

    private bool _loaded;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ValidationResult != null && !ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    protected async Task OnSave()
    {
        var command = new SaveAwardManagement.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Award Detail was saved successfully!", Severity.Success);

        await Load();
    }

    private async Task Load()
    {
        if (AwardTypeId == 0)
            return;

        Entity.AwardDetail awardDetail = await QueryRouter.Send(new GetAwardManagement(AwardTypeId));

        if (awardDetail == null)
        {
            EditModel.AwardType = AwardType.Find(AwardTypeId);
            _loaded = true;
            return;
        }

        EditModel = awardDetail.ToEditModel();

        _loaded = true;
    }
}
