namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments;

public abstract class AccomplishmentRule
{
    public abstract Constant.AccomplishmentType AccomplishmentType { get; }

    public virtual bool Applies(Constant.AccomplishmentType accomplishmentType)
    {
        return accomplishmentType == AccomplishmentType;
    }

    protected string[] GetDateAccomplishmentAbbreviations(Entity.PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Date.Value:M/d/yy} {AccomplishmentType.Abbreviation}")
                    .ToArray();
    }

    protected string[] GetDateAccomplishmentNames(Entity.PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Date.Value:M/d/yy} {AccomplishmentType.Name}")
                    .ToArray();
    }

    protected string GetMultipleAccomplishmentName(Entity.PersonAccomplishment[] items)
    {
        return $"{items.Length} {AccomplishmentType.Name}s";
    }

    protected string GetMultipleTimeAccomplishmentAbbreviation(Entity.PersonAccomplishment[] items)
    {
        return $"{items.Length}x {AccomplishmentType.Abbreviation}";
    }

    protected string GetMultipleTimeAccomplishmentName(Entity.PersonAccomplishment[] items)
    {
        return $"{items.Length}x {AccomplishmentType.Name}";
    }

    protected string[] GetYearlyAccomplishmentAbbreviations(Entity.PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Year.Value} {AccomplishmentType.Abbreviation}")
                    .ToArray();
    }

    protected string[] GetYearlyAccomplishmentNames(Entity.PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Year.Value} {AccomplishmentType.Name}")
                    .ToArray();
    }
}
