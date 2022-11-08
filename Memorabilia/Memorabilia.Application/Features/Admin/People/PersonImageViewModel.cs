using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class PersonImageViewModel
{
    private readonly Person _person;

    public PersonImageViewModel() { }

    public PersonImageViewModel(Person person)
    {
        _person = person;
    }

    public string ImageFileName => _person.ImagePath;

    public int PersonId => _person.Id;
}
