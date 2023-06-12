namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonAutoComplete 
    : NamedEntityAutoComplete<PersonEditModel>, INotifyPropertyChanged
{   
    [Parameter]
    public Sport Sport { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    public PersonAutoComplete()
    {
        PropertyChanged += PersonAutoComplete_PropertyChanged;
    }    

    protected override async Task OnInitializedAsync()
    {
        Label = "Person";
        Placeholder = "Search by name...";

        await LoadItems();
    }

    private async Task LoadItems()
    {
        Entity.Person[] people = await QueryRouter.Send(new GetPeople(SportId: Sport?.Id ?? null));

        Items = people.Select(person => new PersonEditModel(new PersonModel(person)));
    }

    private async void PersonAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }
}
