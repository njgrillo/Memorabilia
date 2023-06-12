namespace Memorabilia.Application.Features.Admin.People;

public class PersonImageModel
{
    private readonly Entity.Person _person;

    public PersonImageModel() { }

    public PersonImageModel(Entity.Person person)
    {
        _person = person;
    }

    public string ImageFileName 
        => _person.ImageFileName;

    public int PersonId 
        => _person.Id;
}
