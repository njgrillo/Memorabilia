namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AwardProfileModel
{
    private readonly Entity.PersonAward _award;

    public AwardProfileModel(Entity.PersonAward award)
    {
        _award = award;
    }

    public Constant.AwardType AwardType 
        => Constant.AwardType.Find(AwardTypeId);

    public string AwardTypeAbbreviatedName 
        => AwardType?.ToString() ?? string.Empty;

    public int AwardTypeId => _award.AwardTypeId;

    public string AwardTypeName 
        => AwardType?.Name ?? string.Empty;

    public int Year => _award.Year;

    public override string ToString()
    {
        return AwardType.Abbreviation ?? AwardTypeName;
    }
}
