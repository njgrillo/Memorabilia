using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class BattingTripleCrownRule : AccomplishmentRule, IAccomplishmentRule
{
    private Domain.Constants.AccomplishmentType _accomplishmentType;

    public override Domain.Constants.AccomplishmentType AccomplishmentType
        => _accomplishmentType;

    public override bool Applies(Domain.Constants.AccomplishmentType accomplishmentType)
    {
        _accomplishmentType = accomplishmentType; 

        return accomplishmentType == Domain.Constants.AccomplishmentType.AmericanLeagueTripleCrown ||
               accomplishmentType == Domain.Constants.AccomplishmentType.NationalLeagueTripleCrown;
    }

    public string[] GenerateInscriptions(PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}",
            $"{AccomplishmentType.Name}",
            "TC",
        };

        if (accomplishments.Length > 1)
        {
            inscriptions.Add(GetMultipleTimeAccomplishmentAbbreviation(accomplishments));
            inscriptions.Add(GetMultipleTimeAccomplishmentName(accomplishments));
        }

        PersonAccomplishment[] items = accomplishments.Where(x => x.Year.HasValue).ToArray();

        inscriptions.AddRange(GetYearlyAccomplishmentAbbreviations(items));
        inscriptions.AddRange(GetYearlyAccomplishmentNames(items));

        return inscriptions.ToArray();
    }
}
