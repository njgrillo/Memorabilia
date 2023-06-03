namespace Memorabilia.Blazor.Pages.Collection;

public partial class CollectionEditor
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public CollectionValidator Validator { get; set; }

    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected ValidationResult ValidationResult { get; set; }

    protected Alert[] ValidationResultAlerts => ValidationResult != null
        ? ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
        : Array.Empty<Alert>();

    protected CollectionEditModel Model = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ValidationResult != null && !ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
        {
            Model = new CollectionEditModel
            {
                UserId = UserId
            };

            return;
        }

        Domain.Entities.Collection collection = await QueryRouter.Send(new GetCollection(Id));

        Model = new CollectionEditModel(collection);
    }

    protected async Task AddMemorabilia()
    {
        var parameters = new DialogParameters
        {
            ["UserId"] = Model.UserId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        //TODO: Create a select memorabilia dialog
        var dialog = DialogService.Show<SelectAutographDialog>("Select Memorabilia", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<CollectionMemorabiliaEditModel>)result.Data;

        Model.Items.AddRange(items);
    }

    protected async Task OnSave()
    {
        var command = new SaveCollection.Command(Model);

        Model.ValidationResult = Validator.Validate(command);

        if (!Model.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Collection was saved successfully!", Severity.Success);
    }
}
