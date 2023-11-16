namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AwardProfileModel(Entity.PersonAward award)
{
    public Constant.AwardType AwardType 
        => Constant.AwardType.Find(AwardTypeId);

    public string AwardTypeAbbreviatedName 
        => AwardType?.ToString() ?? string.Empty;

    public int AwardTypeId => award.AwardTypeId;

    public string AwardTypeName 
        => AwardType?.Name ?? string.Empty;

    public int Year 
        => award.Year;

    public override string ToString()
        => AwardType.Abbreviation ?? AwardTypeName;
}
