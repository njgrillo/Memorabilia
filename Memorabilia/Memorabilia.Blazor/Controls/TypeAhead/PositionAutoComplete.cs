namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PositionAutoComplete : DomainEntityAutoComplete<Domain.Constants.Position>
{
    [Parameter]
    public Sport[] Sports { get; set; } = Array.Empty<Sport>();

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
        Items = Sports != null && Sports.Any() 
            ? Domain.Constants.Position.GetAll(Sports) 
            : Domain.Constants.Position.All;
    }
}
