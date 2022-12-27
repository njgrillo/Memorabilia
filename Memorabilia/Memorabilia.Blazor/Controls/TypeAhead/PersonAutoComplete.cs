namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonAutoComplete : NamedEntityAutoComplete<SavePersonViewModel>, INotifyPropertyChanged
{   
    [Parameter]
    public Sport Sport { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

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
        Items = (await QueryRouter.Send(new GetPeople(Sport?.Id ?? null))).People.Select(person => new SavePersonViewModel(person));
    }

    private async void PersonAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }
}
