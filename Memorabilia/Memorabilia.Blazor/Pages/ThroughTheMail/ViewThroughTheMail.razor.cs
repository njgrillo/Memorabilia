namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ViewThroughTheMail
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected List<ThroughTheMailModel> Items { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Entity.ThroughTheMail[] throughTheMails = await QueryRouter.Send(new GetThroughTheMails());

        Items = throughTheMails.Select(throughTheMail => new ThroughTheMailModel(throughTheMail))
                               .ToList(); 
    }    

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
}
