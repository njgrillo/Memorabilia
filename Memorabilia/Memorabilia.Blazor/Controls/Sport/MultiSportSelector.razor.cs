#nullable disable

namespace Memorabilia.Blazor.Controls.Sport;

public partial class MultiSportSelector : ComponentBase
{

    [Parameter]
    public bool CanToggle { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public EventCallback<IEnumerable<int>> SelectedSportIdsChanged { get; set; }

    [Parameter]
    public List<int> SportIds { get; set; } = new();

    private bool _displaySports;
    private bool _hasSport;
    private string _itemTypeNameLabel => $"Associate {ItemType?.Name} with Sports";
    private int _sportId;

    protected override void OnInitialized()
    {
        _displaySports = CanToggle && SportIds.Any();
        _hasSport = SportIds.Any();
    }

    private static string GetMultiSelectionText(List<string> selectedValues)
    {
        List<int> items = new();

        foreach (var item in selectedValues)
        {
            items.Add(item.ToInt32());
        }

        var selectedSports = Domain.Constants.Sport.All.Where(sport => items.Contains(sport.Id)).OrderBy(sport => sport.Name);

        if (selectedSports.Count() < 5)
        {
            return string.Join(", ", selectedSports.Select(sport => sport.Name));
        }
        else
            return $"{selectedSports.Count()} sports have been selected";
    }

    private void SportCheckboxClicked(bool isChecked)
    {
        _displaySports = CanToggle && isChecked;

        if (!_displaySports)
        {
            SportIds = new();
        }

        _hasSport = isChecked;
    }
}
