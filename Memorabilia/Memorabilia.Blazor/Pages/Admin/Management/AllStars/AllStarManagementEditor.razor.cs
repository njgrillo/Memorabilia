namespace Memorabilia.Blazor.Pages.Admin.Management.AllStars;

public partial class AllStarManagementEditor
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public AllStarManagementValidator Validator { get; set; }

    [Parameter]
    public int AllStarDetailId { get; set; }

    protected AllStarManagementEditModel EditModel { get; set; }
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
        var command = new SaveAllStarManagement.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("All Star Detail was saved successfully!", Severity.Success);

        await Load();
    }

    private async Task Load()
    {
        if (AllStarDetailId == 0)
            return;

        Entity.AllStarDetail allStarDetail 
            = await Mediator.Send(new GetAllStarManagement(AllStarDetailId));

        if (allStarDetail == null)
        {
            _loaded = true;
            return;
        }

        EditModel = allStarDetail.ToEditModel();

        _loaded = true;
    }
}
