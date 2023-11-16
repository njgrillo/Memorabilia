namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class LeaderProfileModel(Entity.Leader leader)
{
    public Constant.LeaderType LeaderType 
        => Constant.LeaderType.Find(LeaderTypeId);

    public string LeaderTypeAbbreviatedName 
        => LeaderType?.ToString() ?? string.Empty;

    public int LeaderTypeId 
        => leader.LeaderTypeId;

    public string LeaderTypeName 
        => LeaderType?.Name ?? string.Empty;

    public int Year 
        => leader.Year;

    public override string ToString()
        => !LeaderType.Abbreviation.IsNullOrEmpty() 
            ? LeaderType.Abbreviation 
            : LeaderType.Name;
}
