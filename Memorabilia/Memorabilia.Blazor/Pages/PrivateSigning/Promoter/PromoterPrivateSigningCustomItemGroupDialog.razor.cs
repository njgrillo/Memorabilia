namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PromoterPrivateSigningCustomItemGroupDialog
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public CustomItemGroupsValidator Validator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected CustomItemGroupEditModel EditModel { get; set; }
        = new();

    protected CustomItemGroupsEditModel Groups { get; set; }
        = new();

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
        Entity.PrivateSigningCustomItemGroup[] customItemTypeGroups
            = await Mediator.Send(new GetCustomItemGroups());

        Groups = new(customItemTypeGroups, ApplicationStateService.CurrentUser.Id);
    }
    
    public void Add()
    {
        if (EditModel.Name.IsNullOrEmpty() || !EditModel.ItemTypeIds.Any())
            return;

        List<CustomItemTypeGroupEditModel> items 
            = EditModel.ItemTypeIds.Select(x => new CustomItemTypeGroupEditModel(x)).ToList();

        Groups.CustomItemGroups.Add(new CustomItemGroupEditModel(EditModel.Name, items));

        EditModel = new();
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public async Task Save()
    {
        await InternalSave();
    }

    public async Task SaveAndClose()
    {
        await InternalSave();

        MudDialog.Close();
    }

    public void Select(CustomItemGroupEditModel customItemGroup)
    {
        MudDialog.Close(DialogResult.Ok(customItemGroup));
    }

    private async Task InternalSave()
    {
        var command = new SaveCustomItemGroups.Command(Groups);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Custom Item Groups were saved successfully!", Severity.Success);

        Entity.PrivateSigningCustomItemGroup[] customItemTypeGroups
            = await Mediator.Send(new GetCustomItemGroups());

        Groups = new(customItemTypeGroups, ApplicationStateService.CurrentUser.Id);
    }
}
