namespace Memorabilia.Application.Features.Admin.People;

public class PersonTeamsModel
{
    private readonly Entity.Person _person;

    public PersonTeamsModel() { }

    public PersonTeamsModel(Entity.Person person)
    {
        _person = person;
    }

    public int PersonId 
        => _person.Id;

    public List<Entity.PersonSport> Sports
        => _person.Sports;

    public List<Entity.PersonTeam> Teams 
        => _person.Teams;
}
