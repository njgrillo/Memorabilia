﻿namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonDomainAutoComplete 
    : NamedEntityAutoComplete<PersonModel>, INotifyPropertyChanged
{
    [Parameter]
    public Sport Sport { get; set; }

    [Parameter]
    public int SportLeagueLevelId { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

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
        if (e.PropertyName == nameof(SportLeagueLevelId) || e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }        
    }

    private async Task LoadItems()
    {
        Entity.Person[] people 
            = await QueryRouter.Send(new GetPeople(SportId: Sport?.Id ?? null, 
                                                   SportLeagueLevelId: SportLeagueLevelId.ToNullableInt()));

        Items = people.Select(person => new PersonModel(person));
    }
}
