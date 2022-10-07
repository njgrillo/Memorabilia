using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class PersonOccupationViewModel
{
    private readonly Person _person;

    public PersonOccupationViewModel() { }

    public PersonOccupationViewModel(Person person)
    {
        _person = person;
    }

    public List<PersonOccupation> Occupations => _person.Occupations;        

    public int PersonId => _person.Id;

    public List<PersonSport> Sports => _person.Sports;
}
