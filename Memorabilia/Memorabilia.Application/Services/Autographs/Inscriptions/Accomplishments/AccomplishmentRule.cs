namespace Memorabilia.Application.Services.Autographs.Inscriptions.Accomplishments;

public abstract class AccomplishmentRule
{
    public abstract Constant.AccomplishmentType AccomplishmentType { get; }

    public virtual bool Applies(Constant.AccomplishmentType accomplishmentType)
        => accomplishmentType == AccomplishmentType;

    protected string[] GetDateAccomplishmentAbbreviations(Entity.PersonAccomplishment[] items)
        => items.Select(x => $"{x.Date.Value:M/d/yy} {AccomplishmentType.Abbreviation}")
                .ToArray();

    protected string[] GetDateAccomplishmentNames(Entity.PersonAccomplishment[] items)
        => items.Select(x => $"{x.Date.Value:M/d/yy} {AccomplishmentType.Name}")
                .ToArray();

    protected string GetMultipleAccomplishmentName(Entity.PersonAccomplishment[] items)
        => $"{items.Length} {AccomplishmentType.Name}s";

    protected string GetMultipleTimeAccomplishmentAbbreviation(Entity.PersonAccomplishment[] items)
        => $"{items.Length}x {AccomplishmentType.Abbreviation}";

    protected string GetMultipleTimeAccomplishmentName(Entity.PersonAccomplishment[] items)
        => $"{items.Length}x {AccomplishmentType.Name}";

    protected string[] GetYearlyAccomplishmentAbbreviations(Entity.PersonAccomplishment[] items)
        => items.Select(x => $"{x.Year.Value} {AccomplishmentType.Abbreviation}")
                .ToArray();

    protected string[] GetYearlyAccomplishmentNames(Entity.PersonAccomplishment[] items)
        => items.Select(x => $"{x.Year.Value} {AccomplishmentType.Name}")
                .ToArray();
}
