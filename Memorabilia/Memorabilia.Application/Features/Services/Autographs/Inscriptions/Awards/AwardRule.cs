namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards;

public abstract class AwardRule
{
    public abstract Constant.AwardType AwardType { get; }

    public virtual bool Applies(Constant.AwardType awardType)
        => awardType == AwardType;

    protected string GetMultipleAwardName(Entity.PersonAward[] items)
        => $"{items.Length} {AwardType.Name}s";

    protected string GetMultipleTimeAwardAbbreviation(Entity.PersonAward[] items)
        => $"{items.Length}x {AwardType.Abbreviation}";

    protected string GetMultipleTimeAwardName(Entity.PersonAward[] items)
        => $"{items.Length}x {AwardType.Name}";

    protected string[] GetYearlyAwardAbbreviations(Entity.PersonAward[] items)
        => items.Select(x => $"{x.Year} {AwardType.Abbreviation}")
                .ToArray();

    protected string[] GetYearlyAwardNames(Entity.PersonAward[] items)
        => items.Select(x => $"{x.Year} {AwardType.Name}")
                .ToArray();
}
