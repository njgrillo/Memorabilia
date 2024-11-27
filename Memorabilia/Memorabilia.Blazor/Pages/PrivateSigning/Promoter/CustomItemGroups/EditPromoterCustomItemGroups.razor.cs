namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter.CustomItemGroups;

public partial class EditPromoterCustomItemGroups
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

    private CustomItemGroupEditModel _elementBeforeEdit;

    protected CustomItemGroupsEditModel EditModel { get; set; }
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
        EditModel = new(await Mediator.Send(new GetCustomItemGroups()), ApplicationStateService.CurrentUser.Id);
    }

    private void AddCustomItemGroup()
    {
        EditModel.CustomItemGroups.Add(new());
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            Items = ((CustomItemGroupEditModel)element).Items,
            Name = ((CustomItemGroupEditModel)element).Name,
        };
    }

    private void Commit(object element)
    {
        var item = (CustomItemGroupEditModel)element;

        IEnumerable<CustomItemTypeGroupEditModel> removedItems 
            = item.Items.Where(x => !item.ItemTypeIds.Contains(x.ItemType.Id));

        IEnumerable<CustomItemTypeGroupEditModel> addedItems
            = item.ItemTypeIds
                  .Where(itemTypeId => !item.Items
                                            .Select(x => x.ItemType.Id)
                                            .Contains(itemTypeId)
                        )
                  .Select(itemTypeId => new CustomItemTypeGroupEditModel(itemTypeId, item.Id));

        item.Items.RemoveAll(x => !item.ItemTypeIds.Contains(x.ItemType.Id));
        item.Items.AddRange(addedItems);
        item.Items = item.Items.OrderBy(x => x.ItemType.Name).ToList();

        CustomItemGroupEditModel customItemGroup 
            = EditModel.CustomItemGroups.SingleOrDefault(x => (item.Id > 0 && x.Id == item.Id) || x.Name == item.Name);

        if (customItemGroup is null)
            return;

        customItemGroup.Items = item.Items;
        customItemGroup.ItemTypeIds = item.ItemTypeIds;
    }

    private async void OnSave()
    {
        var command = new SaveCustomItemGroups.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Custom Item Groups were saved successfully!", Severity.Success);

        EditModel = new(await Mediator.Send(new GetCustomItemGroups()), ApplicationStateService.CurrentUser.Id);
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((CustomItemGroupEditModel)element).Items = _elementBeforeEdit.Items;
        ((CustomItemGroupEditModel)element).Name = _elementBeforeEdit.Name;
    }
}
