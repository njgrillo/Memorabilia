namespace Memorabilia.Application.Features.Admin.People;

public class PersonAccoladeModel
{
    private readonly Entity.Person _person;

    public PersonAccoladeModel() { }

    public PersonAccoladeModel(Entity.Person person)
    {
        _person = person;
    }

    public List<Entity.PersonAccomplishment> Accomplishments 
        => _person.Accomplishments;

    public List<Entity.AllStar> AllStars 
        => _person.AllStars;

    public List<Entity.PersonAward> Awards 
        => _person.Awards;

    public List<Entity.CareerRecord> CareerRecords 
        => _person.CareerRecords;

    public List<Entity.CollegeRetiredNumber> CollegeRetiredNumbers 
        => _person.CollegeRetiredNumbers;

    public Constant.College[] Colleges 
        => _person.Colleges
                  .Select(college => Constant.College.Find(college.CollegeId))
                  .ToArray();

    public List<Entity.Leader> Leaders 
        => _person.Leaders;

    public int PersonId 
        => _person.Id;

    public List<Entity.RetiredNumber> RetiredNumbers 
        => _person.RetiredNumbers;

    public List<Entity.SingleSeasonRecord> SingleSeasonRecords 
        => _person.SingleSeasonRecords;

    public List<Entity.PersonSport> Sports
        => _person.Sports;
}
