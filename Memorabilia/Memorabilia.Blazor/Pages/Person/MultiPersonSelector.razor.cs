namespace Memorabilia.Blazor.Pages.Person;

public partial class MultiPersonSelector
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public bool CanFilterBySport { get; set; }

    [Parameter]
    public bool CanToggle { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public List<PersonEditModel> SelectedPeople { get; set; }

    [Parameter]
    public EventCallback<List<PersonEditModel>> SelectedPeopleChanged { get; set; }

    protected PersonEditModel SelectedPerson { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private bool _displayPeople;

    private bool _filterPeople 
        = true;

    private bool _hasPeople;

    private string _itemTypeNameLabel 
        => $"Associate {ItemType.Name} with People";

    private string _itemTypeNameFilterLabel 
        => $"Filter by {Sport?.Name}";

    private Sport _sportFilter;

    protected override void OnInitialized()
    {
        _hasPeople = SelectedPerson?.Id > 0 || 
                     SelectedPeople.Count != 0;

        _displayPeople = !CanToggle || 
                         _hasPeople;  

        _sportFilter = Sport;

        if (!_filterPeople)
            Sport = null;
    }

    private void Add()
    {
        PersonEditModel person 
            = SelectedPeople.SingleOrDefault(person => person.Id == SelectedPerson.Id);

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
            SelectedPeople = [];
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

    private async Task ShowPersonProfile(int personId)
    {
        var parameters = new DialogParameters
        {
            ["PersonId"] = personId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);
        
        await dialog.Result;
    }
}
