namespace Memorabilia.Blazor.Controls.TypeAhead;

public class AccomplishmentTypeAutoComplete 
    : DomainEntityAutoComplete<AccomplishmentType>
{
    [Parameter]
    public Sport[] Sports { get; set; } 
        = [];

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Accomplishment Type";
        Placeholder = "Search by accomplishment...";
        ResetValueOnEmptyText = true;

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
        Items = Sports.HasAny()
            ? AccomplishmentType.GetAll(Sports) 
            : AccomplishmentType.All;
    }
}
