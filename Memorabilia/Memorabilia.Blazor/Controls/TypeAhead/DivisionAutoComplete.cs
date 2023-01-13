namespace Memorabilia.Blazor.Controls.TypeAhead;

public class DivisionAutoComplete : DomainEntityAutoComplete<Division>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Brand";
        Placeholder = "Search by Brand...";

        LoadItems();
    }

    protected override void OnParametersSet()
    {
        if (_loaded)
            return;

        LoadItems();

        _loaded = true;
    }

    private void LoadItems()
    {
        Items = SportLeagueLevel != null 
            ? Division.GetAll(SportLeagueLevel)
            : Division.All;
    }
}
