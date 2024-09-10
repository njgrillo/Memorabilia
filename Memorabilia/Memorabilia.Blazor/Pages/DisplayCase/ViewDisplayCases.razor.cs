namespace Memorabilia.Blazor.Pages.DisplayCase;

public partial class ViewDisplayCases
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected DisplayCasesModel Model
        = new();

    protected async Task Delete(int id)
    {
        DisplayCaseModel deletedItem
            = Model.DisplayCases.Single(displayCase => displayCase.Id == id);

        var model = new DisplayCaseEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveDisplayCase.Command(model));

        Model.DisplayCases.Remove(deletedItem);

        Snackbar.Add("Display Case was deleted successfully!", Severity.Success);
    }

    protected async Task<TableData<DisplayCaseModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetDisplayCasesPaged(pageInfo));

        StateHasChanged();

        return new TableData<DisplayCaseModel>()
        {
            Items = Model.DisplayCases,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
