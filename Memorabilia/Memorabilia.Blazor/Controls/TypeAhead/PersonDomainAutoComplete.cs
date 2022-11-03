#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonDomainAutoComplete : NamedEntityAutoComplete<PersonViewModel>, INotifyPropertyChanged
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

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
        if (e.PropertyName == nameof(SportLeagueLevelId))
        {
            await LoadItems();
        }        
    }

    private async Task LoadItems()
    {
        Items = (await QueryRouter.Send(new GetPeople(SportLeagueLevelId: SportLeagueLevelId > 0 ? SportLeagueLevelId : null))).People;
    }
}
