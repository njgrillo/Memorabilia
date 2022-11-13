#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class AwardTypeAutoComplete : DomainEntityAutoComplete<AwardType>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

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
        if (SportIds != null && SportIds.Any())
        {
            Items = AwardType.GetAll(SportIds);
            return;
        }            

        if (SportLeagueLevel != null)
        {
            Items = AwardType.GetAll(SportLeagueLevel);
            return;
        }           

        Items = AwardType.All;
    }
}
