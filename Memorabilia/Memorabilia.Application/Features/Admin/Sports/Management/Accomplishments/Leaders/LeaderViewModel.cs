namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Leaders;

public class LeaderViewModel
{
    private readonly Entity.Leader _leader;

    public LeaderViewModel() { }

    public LeaderViewModel(Entity.Leader leader)
    {
        _leader = leader;
    }

    public int Id
        => _leader.Id;    

    public int LeaderTypeId
        => _leader.LeaderTypeId;

    public string LeaderTypeName
        => Constant.LeaderType.Find(_leader.LeaderTypeId)?.Name;

    public int PersonId
        => _leader.PersonId;

    public int Year
        => _leader.Year;
}
