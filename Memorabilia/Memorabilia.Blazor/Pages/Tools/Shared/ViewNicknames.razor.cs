namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewNicknames
    : ViewSportTools<PersonNicknameViewModel>
{
    protected PersonNicknamesViewModel Model
        = new();

    private MudTable<PersonNicknameViewModel> _table
       = new();

    protected void Filter(string search)
    {
        Search = search;

        _table.ReloadServerData();
    }

    protected async Task<TableData<PersonNicknameViewModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetNicknames(pageInfo, Sport?.Id, Search));

        StateHasChanged();

        switch (state.SortLabel)
        {
            case "personname_field":
                Model.Persons = Model.Persons.OrderByDirection(state.SortDirection, o => o.PersonName).ToList();
                break;
        }

        return new TableData<PersonNicknameViewModel>()
        {
            Items = Model.Persons,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
