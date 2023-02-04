using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards;

public abstract class AwardRule
{
    public abstract Domain.Constants.AwardType AwardType { get; }

    public virtual bool Applies(Domain.Constants.AwardType awardType)
    {
        return awardType == AwardType;
    }

    protected string GetMultipleAwardName(PersonAward[] items)
    {
        return $"{items.Length} {AwardType.Name}s";
    }

    protected string GetMultipleTimeAwardAbbreviation(PersonAward[] items)
    {
        return $"{items.Length}x {AwardType.Abbreviation}";
    }

    protected string GetMultipleTimeAwardName(PersonAward[] items)
    {
        return $"{items.Length}x {AwardType.Name}";
    }

    protected string[] GetYearlyAwardAbbreviations(PersonAward[] items)
    {
        return items.Select(x => $"{x.Year} {AwardType.Abbreviation}")
                    .ToArray();
    }

    protected string[] GetYearlyAwardNames(PersonAward[] items)
    {
        return items.Select(x => $"{x.Year} {AwardType.Name}")
                    .ToArray();
    }
}
