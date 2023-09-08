namespace Memorabilia.Blazor.Pages.Person;

public partial class SearchPersonSelector
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public List<Entity.Person> SelectedPeople { get; set; }

    [Parameter]
    public EventCallback<List<Entity.Person>> SelectedPeopleChanged { get; set; }

    protected Entity.Person SelectedPerson { get; set; }

    private void Add()
    {
        if ((SelectedPerson?.Id ?? 0) == 0)
            return;

        Entity.Person person 
            = SelectedPeople.SingleOrDefault(person => person.Id == SelectedPerson.Id);

        if (person == null)
        {
            SelectedPeople.Add(SelectedPerson);
            SelectedPeopleChanged.InvokeAsync(SelectedPeople);
        }

        SelectedPerson = new();
    }

    private void RemovePerson(Entity.Person person)
    {
        Entity.Person removedPerson = SelectedPeople.SingleOrDefault(p => p.Id == person.Id);

        if (removedPerson != null)
        {
            SelectedPeople.Remove(removedPerson);
        }
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
        var result = await dialog.Result;
    }
}
