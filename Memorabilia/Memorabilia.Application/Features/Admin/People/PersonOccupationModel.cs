namespace Memorabilia.Application.Features.Admin.People;

public class PersonOccupationModel
{
    private readonly Entity.Person _person;

    public PersonOccupationModel() { }

    public PersonOccupationModel(Entity.Person person)
    {
        _person = person;
    }

    public List<Entity.PersonOccupation> Occupations 
        => _person.Occupations;        

    public int PersonId 
        => _person.Id;

    public List<Entity.PersonPosition> Positions 
        => _person.Positions;

    public List<Entity.PersonSport> Sports 
        => _person.Sports;
}
