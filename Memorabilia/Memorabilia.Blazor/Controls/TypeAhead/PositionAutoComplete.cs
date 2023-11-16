namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PositionAutoComplete : DomainEntityAutoComplete<Constant.Position>
{
    [Parameter]
    public Sport[] Sports { get; set; } 
        = [];

    private bool _loaded;

    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
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
        Items = Sports != null && 
                Sports.Length != 0
            ? Constant.Position.GetAll(Sports) 
            : Constant.Position.All;
    }
}
