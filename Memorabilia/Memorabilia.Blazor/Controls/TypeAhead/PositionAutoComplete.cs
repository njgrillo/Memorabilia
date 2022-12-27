namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PositionAutoComplete : DomainEntityAutoComplete<Domain.Constants.Position>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Position";
        Placeholder = "Search by position...";

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
        Items = SportIds != null && SportIds.Any() ? Domain.Constants.Position.GetAll(SportIds) : Domain.Constants.Position.All;
    }
}
