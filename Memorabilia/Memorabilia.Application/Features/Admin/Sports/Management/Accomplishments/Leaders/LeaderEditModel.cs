namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Leaders;

public class LeaderEditModel : EditModel
{
    public LeaderEditModel() { }

    public LeaderEditModel(Entity.Leader leader, int? year = null)
    {
        Id = leader.Id;
        LeaderTypeId = leader.LeaderTypeId;
        Person = new PersonModel(leader.Person);       
        Year = year ?? leader.Year;
    }

    public LeaderEditModel(int personId, int leaderTypeId, int? year)
    {
        LeaderTypeId = leaderTypeId;
        PersonId = personId;        
        TemporaryId = Guid.NewGuid();
        Year = year;
    }

    public int LeaderTypeId { get; set; }

    public string LeaderTypeName
        => Constant.LeaderType.Find(LeaderTypeId)?.Name;

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }  

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }
}
