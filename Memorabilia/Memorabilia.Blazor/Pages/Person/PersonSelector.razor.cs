namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonSelector
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public bool CanFilterBySport { get; set; }

    [Parameter]
    public bool CanToggle { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public PersonEditModel SelectedPerson { get; set; }

    [Parameter]
    public EventCallback<PersonEditModel> SelectedPersonChanged { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    public PersonEditModel Model
    {
        get => SelectedPerson;
        set
        {
            SelectedPerson = value;
            SelectedPersonChanged.InvokeAsync(value);
        }
    }

    private bool _displayPeople;

    private bool _filterPeople 
        = true;

    private bool _hasPeople;

    private string _itemTypeNameLabel 
        => $"Associate {ItemType.Name} with a Person";

    private string _itemTypeNameFilterLabel
        => $"Filter by {Sport?.Name}";

    private Sport _sportFilter;

    protected override void OnParametersSet()
    {
        _hasPeople = SelectedPerson?.Id > 0;
        _displayPeople = !CanToggle || _hasPeople;
        _sportFilter = Sport;

        if (!_filterPeople)
            Sport = null;
    }

    private void PersonCheckboxClicked(bool isChecked)
    {
        _displayPeople = CanToggle && isChecked;

        if (!_displayPeople)
            Model = null;

        _hasPeople = isChecked;
    }

    private void PersonFilterCheckboxClicked(bool isChecked)
    {
        _filterPeople = isChecked;

        Sport = _filterPeople 
            ? _sportFilter 
            : null;
    }

    private async Task ShowPersonProfile()
    {
        if (!_hasPeople)
            return;

        var parameters = new DialogParameters
        {
            ["PersonId"] = SelectedPerson.Id
        };

        var options = new DialogOptions()
        {            
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;
    }
}
