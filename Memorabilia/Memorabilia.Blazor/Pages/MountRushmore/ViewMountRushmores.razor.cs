namespace Memorabilia.Blazor.Pages.MountRushmore;

public partial class ViewMountRushmores
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected MountRushmoresModel Model
        = new();

    private string _search;
    private MudTable<MountRushmoreModel> _table;

    protected async Task Delete(int id)
    {
        MountRushmoreModel deletedItem
            = Model.MountRushmores.Single(mountRushmore => mountRushmore.Id == id);

        var model = new MountRushmoreEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveMountRushmore.Command(model));

        Model.MountRushmores.Remove(deletedItem);

        Snackbar.Add("Mount Rushmore was deleted successfully!", Severity.Success);
    }

    private void Filter(string search)
    {
        _search = search;

        _table.ReloadServerData();
    }

    protected async Task<TableData<MountRushmoreModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetMountRushmoresPaged(pageInfo, _search));

        StateHasChanged();

        switch (state.SortLabel)
        {
            case "name_field":
                Model.MountRushmores = Model.MountRushmores.OrderByDirection(state.SortDirection, o => o.Name).ToList();
                break;
            case "description_field":
                Model.MountRushmores = Model.MountRushmores.OrderByDirection(state.SortDirection, o => o.Description).ToList();
                break;
            case "privacytype_field":
                Model.MountRushmores = Model.MountRushmores.OrderByDirection(state.SortDirection, o => o.PrivacyTypeName).ToList();
                break;
        }

        return new TableData<MountRushmoreModel>()
        {
            Items = Model.MountRushmores,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
