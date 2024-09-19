namespace Memorabilia.Application.Features.Admin.People;

public class PersonLeaderEditModel : EditModel
{
    public PersonLeaderEditModel() { }

    public PersonLeaderEditModel(Constant.LeaderType leaderType, int year)
    {
        LeaderType = leaderType;
        Year = year;
    }

    public PersonLeaderEditModel(Entity.Leader leader)
    {
        LeaderType = Constant.LeaderType.Find(leader.LeaderTypeId);
        Id = leader.Id;
        PersonId = leader.PersonId;
        Year = leader.Year;
    }

    public Constant.LeaderType LeaderType { get; set; }

    public string LeaderTypeName 
        => LeaderType?.Name;

    public int PersonId { get; set; }

    public int Year { get; set; }

    public bool Search(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
           LeaderTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (isNumeric && Year == year);
    }
}
