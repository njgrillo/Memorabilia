#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class MultiPersonSelector : ComponentBase
{
    [Parameter]
    public bool CanFilterBySport { get; set; }

    [Parameter]
    public bool CanToggle { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public List<SavePersonViewModel> SelectedPeople { get; set; }

    [Parameter]
    public EventCallback<List<SavePersonViewModel>> SelectedPeopleChanged { get; set; }

    protected SavePersonViewModel SelectedPerson { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private bool _displayPeople;
    private bool _filterPeople = true;
    private bool _hasPeople;
    private string _itemTypeNameLabel => $"Associate {ItemType.Name} with People";
    private string _itemTypeNameFilterLabel => $"Filter by {Sport?.Name}";
    private Sport _sportFilter;

    protected override void OnInitialized()
    {
        _hasPeople = SelectedPerson?.Id > 0 || SelectedPeople.Any();
        _displayPeople = !CanToggle || _hasPeople;  
        _sportFilter = Sport;

        if (!_filterPeople)
            Sport = null;
    }

    private void Add()
    {
        var person = SelectedPeople.SingleOrDefault(person => person.Id == SelectedPerson.Id);

        if (person != null)
            person.IsDeleted = false;
        else
        {
            SelectedPeople.Add(SelectedPerson);
            SelectedPeopleChanged.InvokeAsync(SelectedPeople);
        }            

        SelectedPerson = new();
    }

    private void PersonCheckboxClicked(bool isChecked)
    {
        _displayPeople = CanToggle && isChecked;

        if (!_displayPeople)
        {
            SelectedPerson = new();
            SelectedPeople = new();
            SelectedPeopleChanged.InvokeAsync(SelectedPeople);
        }

        _hasPeople = isChecked;
    }

    private void PersonFilterCheckboxClicked(bool isChecked)
    {
        _filterPeople = isChecked;

        if (_filterPeople)
            Sport = _sportFilter;
    }
}
