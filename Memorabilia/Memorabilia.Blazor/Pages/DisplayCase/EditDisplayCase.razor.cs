namespace Memorabilia.Blazor.Pages.DisplayCase;

public partial class EditDisplayCase
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
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public DisplayCaseValidator Validator { get; set; }

    [Parameter]
    public string EncryptId { get; set; }

    protected int ColumnCount;

    protected bool DropZonesLoaded;

    protected DisplayCaseEditModel EditModel
        = new();

    protected int Id;

    protected bool Loaded;

    protected Entity.Memorabilia SelectedMemorabilia { get; set; }
        = new();

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.HasErrors()
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];

    private MudDropContainer<DisplayCaseMemorabiliaEditModel> _displayCaseContainer;

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
            EditModel = new DisplayCaseEditModel
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

        var dialog = DialogService.Show<AddDisplayCaseMemorabiliaDialog>(string.Empty,
                                                                         [],
                                                                         options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        int[] memorabiliaIds = EditModel.Memorabilias.Select(x => x.Memorabilia.Id).ToArray();

        List<DisplayCaseMemorabiliaEditModel> selectedMemorabilia
            = items.Where(item => !memorabiliaIds.Contains(item.Memorabilia.Id))
                   .Select(item => new DisplayCaseMemorabiliaEditModel
                   {
                        Identifier = "memorabilia",
                        Memorabilia = item.Memorabilia
                    })
                   .ToList();

        EditModel.Memorabilias.AddRange(selectedMemorabilia);

        RefreshDisplayCaseContainer();
    }

    private void DisplayCaseItemUpdated(MudItemDropInfo<DisplayCaseMemorabiliaEditModel> dropItem)
    {
        dropItem.Item.Identifier = dropItem.DropzoneIdentifier;

        DisplayCaseMemorabiliaEditModel memorabilia
            = EditModel.Memorabilias.SingleOrDefault(x => x.Memorabilia.Id == dropItem.Item.Memorabilia.Id);

        if (memorabilia != null && dropItem.Item.Identifier == "memorabilia")
        {
            memorabilia.IsDeleted = true;
            return;
        }

        _ = dropItem.Item.Identifier.TryParse(out int yPosition);

        UpdateXPosition(memorabilia.XPosition, dropItem.IndexInZone, memorabilia.YPosition.ToString(), dropItem.DropzoneIdentifier);

        if (memorabilia == null)
        {
            EditModel.Memorabilias.Add(
                new DisplayCaseMemorabiliaEditModel(
                    EditModel.Id, 
                    dropItem.Item.Memorabilia.Id, 
                    dropItem.IndexInZone, 
                    yPosition
                    )
                );

            return;
        }

        memorabilia.Identifier = yPosition.ToString();
        memorabilia.IsDeleted = false;
        memorabilia.XPosition = dropItem.IndexInZone;
        memorabilia.YPosition = yPosition;
    }

    private async Task Load()
    {
        Entity.DisplayCase displayCase = await Mediator.Send(new GetDisplayCase(Id));

        EditModel = new DisplayCaseEditModel(displayCase);

        if (EditModel.Memorabilias.Count == 0)
            return;

        ColumnCount = EditModel.Memorabilias.Where(x => !x.IsDeleted).Max(memorabilia => memorabilia.YPosition) + 1;
    }    

    protected async Task OnSave()
    {
        List<DisplayCaseMemorabiliaEditModel> items 
            = EditModel.Memorabilias.Where(x => x.Identifier == "memorabilia").ToList();

        if (items.Count > 0)
            EditModel.Memorabilias.RemoveAll(x => x.Identifier == "memorabilia");

        var command = new SaveDisplayCase.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Display Case was saved successfully!", Severity.Success);

        Id = command.Id;

        EditModel.Memorabilias.AddRange(items);

        await Load();
    }

    private void RefreshDisplayCaseContainer()
    {
        StateHasChanged();

        _displayCaseContainer.Refresh();
    }

    private void Remove(int memorabiliaId)
    {
        DisplayCaseMemorabiliaEditModel memorabilia
            = EditModel.Memorabilias.SingleOrDefault(x => x.Memorabilia.Id == memorabiliaId);

        if (memorabilia == null)
            return;

        memorabilia.IsDeleted = true;
        memorabilia.Removed = true;

        RefreshDisplayCaseContainer();
    }

    private void UpdateXPosition(int oldXPosition, int newXPosition, string droppedFromIdentifier, string droppedToIdentifier)
    {
        if (droppedFromIdentifier == droppedToIdentifier)
        {
            //TODO: Fix 
            ////Same Column, old = -1, new = 0,5,11, [0,1,2,3,4,5,6,7,8,9,10]            
            //if (oldXPosition == -1)
            //{
            //    foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier))
            //    {
            //        if (item.XPosition >= newXPosition)
            //        {
            //            item.XPosition++;
            //        }
            //    }
            //}
            //else
            //{
            //    //Same Column, old = 3, new = 0,5,11, [0,1,2,3,4,5,6,7,8,9,10]
            //    foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier))
            //    {
            //        if (item.XPosition >= newXPosition && item.XPosition < oldXPosition)
            //        {
            //            item.XPosition--;
            //        }
            //    }
            //}









            if (oldXPosition != newXPosition)
            {
                if (oldXPosition > newXPosition)
                {
                    //same column, old = 10, newPosition = 5, moved up
                    foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier && x.XPosition < oldXPosition && x.XPosition >= newXPosition))
                    {
                        item.XPosition++;
                    }
                    //foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier && x.XPosition >= newXPosition))
                    //{
                    //    var name = item.DisplayName;
                    //    item.XPosition++;
                    //}
                }
                else
                {
                    //same column, old = 5, newPosition = 10, moved down
                    foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier && x.XPosition > oldXPosition && x.XPosition <= newXPosition))
                    {
                        item.XPosition--;
                    }
                    //if (oldXPosition == -1)
                    //{
                    //    foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier && x.XPosition > newXPosition))
                    //    {
                    //        var name = item.DisplayName;
                    //        item.XPosition++;
                    //    }
                    //}
                    //else
                    //{
                    //    foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier && x.XPosition > oldXPosition))
                    //    {
                    //        var name = item.DisplayName;
                    //        item.XPosition--;
                    //    }
                    //}                    
                }
            }
        }
        else
        {
            //Different Column
            foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedFromIdentifier && x.XPosition > oldXPosition))
            {
                item.XPosition--;
            }

            foreach (DisplayCaseMemorabiliaEditModel item in EditModel.Memorabilias.Where(x => !x.IsDeleted && x.Identifier == droppedToIdentifier && x.XPosition >= newXPosition))
            {
                item.XPosition++;
            }
        }        
    }
}
