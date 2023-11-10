namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ThroughTheMailEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ThroughTheMailValidator Validator { get; set; }

    [Parameter]
    public string EncryptId { get; set; }

    protected ThroughTheMailEditModel EditModel
        = new();

    protected int Id;

    protected bool Loaded;

    protected AddressEditModel SelectedAddress { get; set; }
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
        Id = DataProtectorService.DecryptId(EncryptId);

        if (Id == 0)
        {
            EditModel = new ThroughTheMailEditModel
            {
                UserId = ApplicationStateService.CurrentUser.Id
            };

            Loaded = true;

            return;
        }

        EditModel = new ThroughTheMailEditModel(new ThroughTheMailModel(await Mediator.Send(new GetThroughTheMail(Id))));

        Loaded = true;
    }

    protected async Task AddAutograph()
    {
        var dialogParameters = new DialogParameters
        {
            ["PersonId"] = EditModel.Person.Id,
            ["ReceivedDate"] = EditModel.ReceivedDate,
            ["ThroughTheMailId"] = EditModel.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddThroughTheMailAutographDialog>("Add Autograph",
                                                                          dialogParameters,
                                                                          options);

        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var item = (ThroughTheMailMemorabiliaEditModel)result.Data;

        EditModel.Memorabilia.Add(item);
    }

    protected async Task AddMemorabilia()
    {
        var dialogParameters = new DialogParameters
        {
            ["PersonId"] = EditModel.Person.Id,
            ["ReceivedDate"] = EditModel.ReceivedDate,
            ["ThroughTheMailId"] = EditModel.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddThroughTheMailMemorabiliaDialog>("Add Memorabilia",
                                                                            dialogParameters,
                                                                            options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var item = (ThroughTheMailMemorabiliaEditModel)result.Data;

        EditModel.Memorabilia.Add(item);
    }

    protected async Task OnSave(bool exit)
    {
        var command = new SaveThroughTheMail.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Through the Mail was saved successfully!", Severity.Success);

        if (exit)
        {
            NavigationManager.NavigateTo(NavigationPath.ThroughTheMail);
            return;
        }

        await OnInitializedAsync();
    }
}
