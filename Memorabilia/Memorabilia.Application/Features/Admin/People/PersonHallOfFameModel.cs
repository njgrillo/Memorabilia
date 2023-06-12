namespace Memorabilia.Application.Features.Admin.People;

public class PersonHallOfFameModel
{
    private readonly Entity.Person _person;

    public PersonHallOfFameModel() { }

    public PersonHallOfFameModel(Entity.Person person)
    {
        _person = person;
    }

    public List<Entity.CollegeHallOfFame> CollegeHallOfFames 
        => _person.CollegeHallOfFames;

    public List<Entity.FranchiseHallOfFame> FranchiseHallOfFames 
        => _person.FranchiseHallOfFames;

    public List<Entity.HallOfFame> HallOfFames 
        => _person.HallOfFames;

    public List<Entity.InternationalHallOfFame> InternationalHallOfFames 
        => _person.InternationalHallOfFames;

    public int PersonId 
        => _person.Id;

    public List<Entity.PersonSport> Sports 
        => _person.Sports;  
}
