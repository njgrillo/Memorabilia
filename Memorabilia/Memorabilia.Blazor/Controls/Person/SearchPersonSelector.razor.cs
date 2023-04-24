﻿

namespace Memorabilia.Blazor.Controls.Person;

public partial class SearchPersonSelector : ComponentBase
{
    [Parameter]
    public List<Domain.Entities.Person> SelectedPeople { get; set; }

    [Parameter]
    public EventCallback<List<Domain.Entities.Person>> SelectedPeopleChanged { get; set; }

    protected Domain.Entities.Person SelectedPerson { get; set; }

    private void Add()
    {
        if (SelectedPerson.Id == 0)
            return;

        var person = SelectedPeople.SingleOrDefault(person => person.Id == SelectedPerson.Id);

        if (person == null)
        {
            SelectedPeople.Add(SelectedPerson);
            SelectedPeopleChanged.InvokeAsync(SelectedPeople);
        }

        SelectedPerson = new();
    }

    private void RemovePerson(Domain.Entities.Person person)
    {
        var removedPerson = SelectedPeople.SingleOrDefault(p => p.Id == person.Id);

        if (removedPerson != null)
        {
            SelectedPeople.Remove(removedPerson);
        }
    }
}
