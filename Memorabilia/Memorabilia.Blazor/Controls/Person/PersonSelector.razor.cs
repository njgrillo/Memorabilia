#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonSelector : ComponentBase
{

    [Parameter]
    public bool CanFilterBySport { get; set; }

    [Parameter]
    public bool CanToggle { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public List<SavePersonViewModel> People { get; set; } = new();

    [Parameter]
    public SavePersonViewModel SelectedPerson { get; set; }

    [Parameter]
    public EventCallback<SavePersonViewModel> SelectedPersonChanged { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    public SavePersonViewModel ViewModel
    {
        get => SelectedPerson;
        set
        {
            SelectedPerson = value;
            SelectedPersonChanged.InvokeAsync(value);
        }
    }

    private bool _displayPeople;
    private bool _filterPeople = true;
    private bool _hasPeople;
    private string _itemTypeNameLabel => $"Associate {ItemType.Name} with a Person";
    private string _itemTypeNameFilterLabel => $"Filter by {Sport?.Name}";
    private Sport _sportFilter;

    protected override void OnInitialized()
    {
        _hasPeople = SelectedPerson?.Id > 0 || People.Any();
        _displayPeople = !CanToggle || _hasPeople;        
        _sportFilter = Sport;

        if (!_filterPeople)
            Sport = null;
    }

    private void PersonCheckboxClicked(bool isChecked)
    {
        _displayPeople = CanToggle && isChecked;

        if (!_displayPeople)
            ViewModel = null;

        _hasPeople = isChecked;
    }

    private void PersonFilterCheckboxClicked(bool isChecked)
    {
        _filterPeople = isChecked;

        if (_filterPeople)
            Sport = _sportFilter;
    }
}
