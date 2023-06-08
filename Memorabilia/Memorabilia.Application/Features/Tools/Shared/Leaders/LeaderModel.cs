namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public class LeaderModel : PersonSportToolModel
{
    private readonly Entity.Leader _leader;

    public LeaderModel(Entity.Leader leader, Constant.Sport sport)
    {
        _leader = leader;
        Sport = sport;
    }

    public int LeaderTypeId 
        => _leader.LeaderTypeId;

    public string LeaderTypeName 
        => Constant.LeaderType.Find(LeaderTypeId)?.Name;

    public override int PersonId 
        => _leader.PersonId;

    public override string PersonImageFileName 
        => _leader.Person.ImageFileName;

    public override string PersonName 
        => _leader.Person.DisplayName;

    public string Year 
        => _leader.Year.ToString();
}
