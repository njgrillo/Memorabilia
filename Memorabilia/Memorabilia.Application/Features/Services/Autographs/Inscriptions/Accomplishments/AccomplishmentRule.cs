using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments;

public abstract class AccomplishmentRule
{
    public abstract Domain.Constants.AccomplishmentType AccomplishmentType { get; }

    public virtual bool Applies(Domain.Constants.AccomplishmentType accomplishmentType)
    {
        return accomplishmentType == AccomplishmentType;
    }

    protected string[] GetDateAccomplishmentAbbreviations(PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Date.Value:M/d/yy} {AccomplishmentType.Abbreviation}")
                    .ToArray();
    }

    protected string[] GetDateAccomplishmentNames(PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Date.Value:M/d/yy} {AccomplishmentType.Name}")
                    .ToArray();
    }

    protected string GetMultipleAccomplishmentName(PersonAccomplishment[] items)
    {
        return $"{items.Length} {AccomplishmentType.Name}s";
    }

    protected string GetMultipleTimeAccomplishmentAbbreviation(PersonAccomplishment[] items)
    {
        return $"{items.Length}x {AccomplishmentType.Abbreviation}";
    }

    protected string GetMultipleTimeAccomplishmentName(PersonAccomplishment[] items)
    {
        return $"{items.Length}x {AccomplishmentType.Name}";
    }

    protected string[] GetYearlyAccomplishmentAbbreviations(PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Year.Value} {AccomplishmentType.Abbreviation}")
                    .ToArray();
    }

    protected string[] GetYearlyAccomplishmentNames(PersonAccomplishment[] items)
    {
        return items.Select(x => $"{x.Year.Value} {AccomplishmentType.Name}")
                    .ToArray();
    }
}
