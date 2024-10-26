namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewPersonDates
    : ViewSportTools<LifeDateViewModel>
{
    protected bool IsToday { get; set; }

    protected LifeDatesViewModel Model
        = new();

    protected DateTime? SelectedBirthDate { get; set; }

    protected int? SelectedBirthMonth { get; set; }

    protected DateTime? SelectedBirthMonthDay { get; set; }

    protected int? SelectedBirthYear { get; set; }

    protected DateTime? SelectedDeathDate { get; set; }

    protected int? SelectedDeathMonth { get; set; }

    protected DateTime? SelectedDeathMonthDay { get; set; }

    protected int? SelectedDeathYear { get; set; }

    private MudTable<LifeDateViewModel> _table
       = new();

    protected void Filter(string search)
    {
        Search = search;

        _table.ReloadServerData();
    }

    private void OnIsTodayChanged(bool isToday)
    {
        IsToday = isToday;

        _table.ReloadServerData();
    }

    protected async Task<TableData<LifeDateViewModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(
            new GetLifeDates(
                pageInfo, 
                Sport?.Id, 
                Search,
                IsToday,
                SelectedBirthMonthDay,
                SelectedBirthMonth,
                SelectedBirthYear,
                SelectedBirthDate,
                SelectedDeathMonthDay,
                SelectedDeathMonth,
                SelectedDeathYear,
                SelectedDeathDate)
            );

        StateHasChanged();

        switch (state.SortLabel)
        {
            case "personname_field":
                Model.Persons = Model.Persons.OrderByDirection(state.SortDirection, o => o.PersonName).ToList();
                break;
        }

        return new TableData<LifeDateViewModel>()
        {
            Items = Model.Persons,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private void OnSelectedBirthDateChanged(DateTime? date)
    {
        SelectedBirthDate = date;

        _table.ReloadServerData();
    }

    private void OnSelectedBirthMonthChanged(int? month)
    {
        SelectedBirthMonth = month;

        _table.ReloadServerData();
    }

    private void OnSelectedBirthMonthDayChanged(DateTime? date)
    {
        SelectedBirthMonthDay = date;

        _table.ReloadServerData();
    }

    private void OnSelectedBirthYearChanged(int? year)
    {
        SelectedBirthYear = year;

        _table.ReloadServerData();
    }

    private void OnSelectedDeathDateChanged(DateTime? date)
    {
        SelectedDeathDate = date;

        _table.ReloadServerData();
    }

    private void OnSelectedDeathMonthChanged(int? month)
    {
        SelectedDeathMonth = month;

        _table.ReloadServerData();
    }

    private void OnSelectedDeathMonthDayChanged(DateTime? date)
    {
        SelectedDeathMonthDay = date;

        _table.ReloadServerData();
    }

    private void OnSelectedDeathYearChanged(int? year)
    {
        SelectedDeathYear = year;

        _table.ReloadServerData();
    }
}
