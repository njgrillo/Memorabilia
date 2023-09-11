namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ThroughTheMailGrid
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public PersonFilterService PersonFilterService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public List<ThroughTheMailModel> Items { get; set; }
        = new();

    public bool HasCompletedItems
        => Items.Any(item => item.ReceivedDate.HasValue);  

    protected string Search { get; set; }

    protected async Task Delete(int id)
    {
        ThroughTheMailModel deletedItem
            = Items.Single(throughTheMail => throughTheMail.Id == id);

        var model = new ThroughTheMailEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveThroughTheMail.Command(model));

        Items.Remove(deletedItem);

        Snackbar.Add("TTM was deleted successfully!", Severity.Success);
    }

    protected bool Filter(ThroughTheMailModel model)
    {
        bool dateSearch = DateTime.TryParse(Search, out DateTime date);

        return Search.IsNullOrEmpty() ||
               (dateSearch && (model.SentDate == date || model.ReceivedDate == date)) ||
               string.Equals(model.Status, Search, StringComparison.OrdinalIgnoreCase) ||
               PersonFilterService.Filter(model.Person, Search);
    }

    protected ThroughTheMailMemorabiliaModel[] GetThroughTheMailMemorabiliaModels(int throughTheMailId)
        => Items.Single(item => item.Id == throughTheMailId)
                .Memorabilia
                .Select(memorabilia => new ThroughTheMailMemorabiliaModel(memorabilia))
                .ToArray();

    protected void Navigate(string path)
    {
        NavigationManager.NavigateTo(path);
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete TTM");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Delete(id);
    }

    private async Task ShowPersonProfile(int personId)
    {
        var parameters = new DialogParameters
        {
            ["PersonId"] = personId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;
    }

    private void ToggleChildContent(int throughTheMailId)
    {
        ThroughTheMailModel throughTheMail = Items.Single(item => item.Id == throughTheMailId);

        throughTheMail.DisplayMemorabiliaDetails = !throughTheMail.DisplayMemorabiliaDetails;
        throughTheMail.ToggleIcon = throughTheMail.DisplayMemorabiliaDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
