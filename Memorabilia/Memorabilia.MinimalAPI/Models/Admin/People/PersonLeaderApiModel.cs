namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonLeaderApiModel
{
    private readonly Entity.Leader _leader;

    public PersonLeaderApiModel(Entity.Leader leader)
    {
        _leader = leader;
    }

    public string Name
        => Constant.LeaderType.Find(_leader.LeaderTypeId).Name;

    public int Year
        => _leader.Year;
}
