namespace Memorabilia.Blazor.Pages.Collection;

public partial class CollectionEditor
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
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public CollectionValidator Validator { get; set; }

    [Parameter]
    public string EncryptId { get; set; }

    protected CollectionEditModel EditModel
        = new();

    protected int Id;

    protected bool IsDetailView 
        = true;

    protected bool Loaded;

    protected bool ReloadMemorabiliaGrid;

    protected List<MemorabiliaModel> SelectedMemorabilia 
        = new();

    protected Alert[] ValidationResultAlerts 
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    private MemorabiliaSearchCriteria _filter 
        = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult.IsValid)
            return;

        await JSRuntime.ScrollToAlert();
    }

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
    }

    protected override async Task OnInitializedAsync()
    {
        Id = DataProtectorService.DecryptId(EncryptId);

        if (Id == 0)
        {
            EditModel = new CollectionEditModel
            {
                UserId = ApplicationStateService.CurrentUser.Id
            };

            Loaded = true;

            return;
        }

        await Load();

        Loaded = true;
    }

    protected async Task AddMemorabilia()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddCollectionMemorabiliaDialog>(string.Empty, 
                                                                        new DialogParameters(), 
                                                                        options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        List<CollectionMemorabiliaEditModel> collectionMemorabilias
            = items.Select(item => new CollectionMemorabiliaEditModel
            {
                CollectionId = EditModel.Id,
                MemorabiliaId = item.Id
            }).ToList();

        EditModel.Items.AddRange(collectionMemorabilias);

        StateHasChanged();

        await OnSave();

        ReloadMemorabiliaGrid = true;
    }

    private async Task Load()
    {
        Entity.Collection collection = await Mediator.Send(new GetCollection(Id));

        EditModel = new CollectionEditModel(collection);
    }

    protected async Task OnSave()
    {
        var command = new SaveCollection.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Collection was saved successfully!", Severity.Success);

        Id = command.Id;

        await Load();
    }    
}
