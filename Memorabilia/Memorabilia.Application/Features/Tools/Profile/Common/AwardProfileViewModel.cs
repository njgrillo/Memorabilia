using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AwardProfileViewModel
{
    private readonly PersonAward _award;

    public AwardProfileViewModel(PersonAward award)
    {
        _award = award;
    }

    public Domain.Constants.AwardType AwardType 
        => Domain.Constants.AwardType.Find(AwardTypeId);

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
