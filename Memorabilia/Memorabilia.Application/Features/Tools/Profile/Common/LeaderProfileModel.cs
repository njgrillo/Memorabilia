namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class LeaderProfileModel
{
    private readonly Entity.Leader _leader;

    public LeaderProfileModel(Entity.Leader leader)
    {
        _leader = leader;
    }

    public Constant.LeaderType LeaderType 
        => Constant.LeaderType.Find(LeaderTypeId);

    public string LeaderTypeAbbreviatedName 
        => LeaderType?.ToString() ?? string.Empty;

    public int LeaderTypeId => _leader.LeaderTypeId;

    public string LeaderTypeName 
        => LeaderType?.Name ?? string.Empty;

    public int Year => _leader.Year;

    public override string ToString()
    {
        return !LeaderType.Abbreviation.IsNullOrEmpty() 
            ? LeaderType.Abbreviation
            : LeaderType.Name;
    }
}
