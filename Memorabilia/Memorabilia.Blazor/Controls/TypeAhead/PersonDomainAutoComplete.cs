#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonDomainAutoComplete : NamedEntityAutoComplete<PersonViewModel>, INotifyPropertyChanged
{
    [Parameter]
    public Sport Sport { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public PersonDomainAutoComplete()
    {
        PropertyChanged += PersonDomainAutoComplete_PropertyChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        Label = "Person";
        Placeholder = "Search by name...";

        await LoadItems();
    }

    private async void PersonDomainAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        await LoadItems();
    }

    private async Task LoadItems()
    {
        Items = (await QueryRouter.Send(new GetPeople(Sport?.Id ?? null, SportLeagueLevel?.Id ?? null))).People;
    }
}
