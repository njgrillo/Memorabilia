using System.Runtime.InteropServices;

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

    protected CollectionEditModel Model = new();

    protected List<MemorabiliaItemModel> SelectedMemorabilia = new();

    protected ValidationResult ValidationResult { get; set; }

    protected Alert[] ValidationResultAlerts => ValidationResult != null
        ? ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
        : Array.Empty<Alert>();     

    private MemorabiliaSearchCriteria _filter = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ValidationResult != null && !ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
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

        await Load();
    }

    protected async Task AddMemorabilia()
    {
        var parameters = new DialogParameters
        {
            ["CollectionId"] = Model.Id,
            ["UserId"] = Model.UserId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddCollectionMemorabiliaDialog>("Select Memorabilia", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaItemModel>)result.Data;

        var collectionMemorabilias 
            = items.Select(item => new CollectionMemorabiliaEditModel
              {
                  CollectionId = Model.Id,
                  MemorabiliaId = item.Id
              }).ToList();

        Model.Items.AddRange(collectionMemorabilias);

        await OnSave();
        await Load();
    }

    protected async Task OnSave()
    {
        var command = new SaveCollection.Command(Model);

        Model.ValidationResult = Validator.Validate(command);

        if (!Model.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Collection was saved successfully!", Severity.Success);

        Id = command.Id;

        await Load();
    }

    private async Task Load()
    {
        Entity.Collection collection = await QueryRouter.Send(new GetCollection(Id));

        Model = new CollectionEditModel(collection);
    }
}
