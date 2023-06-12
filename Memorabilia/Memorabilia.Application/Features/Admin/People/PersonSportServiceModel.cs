namespace Memorabilia.Application.Features.Admin.People;

public class PersonSportServiceModel
{
    private readonly Entity.Person _person;

    public PersonSportServiceModel() { }

    public PersonSportServiceModel(Entity.Person person)
    {
        _person = person;
    }

    public List<Entity.PersonCollege> Colleges 
        => _person.Colleges;

    public List<Entity.Draft> Drafts 
        => _person.Drafts;

    public int PersonId 
        => _person.Id;

    public Entity.SportService Service 
        => _person.Service;

    public List<Entity.PersonSport> Sports 
        => _person.Sports;
}
