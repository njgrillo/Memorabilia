namespace Memorabilia.Blazor.Controls.TypeAhead;

public class AccomplishmentTypeAutoComplete : DomainEntityAutoComplete<AccomplishmentType>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

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
        Items = SportIds != null && SportIds.Any() 
            ? AccomplishmentType.GetAll(SportIds) 
            : AccomplishmentType.All;
    }
}
