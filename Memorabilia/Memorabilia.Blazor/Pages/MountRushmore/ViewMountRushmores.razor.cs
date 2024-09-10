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

    protected async Task<TableData<MountRushmoreModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetMountRushmoresPaged(pageInfo));

        StateHasChanged();

        return new TableData<MountRushmoreModel>()
        {
            Items = Model.MountRushmores,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
