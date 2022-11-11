#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class AwardTypeAutoComplete : DomainEntityAutoComplete<AwardType>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Award Type";
        Placeholder = "Search by award...";
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
        Items = SportIds != null && SportIds.Any() ? AwardType.GetAll(SportIds) : AwardType.All;
    }
}
