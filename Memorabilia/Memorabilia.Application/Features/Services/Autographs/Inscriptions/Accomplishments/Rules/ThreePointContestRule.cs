using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class ThreePointContestRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Domain.Constants.AccomplishmentType AccomplishmentType
        => Domain.Constants.AccomplishmentType.NBAThreePointContestChampion;

    public string[] GenerateInscriptions(PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}"
        };

        if (accomplishments.Length > 1)
        {
            inscriptions.Add(GetMultipleTimeAccomplishmentAbbreviation(accomplishments));
        }

        PersonAccomplishment[] items = accomplishments.Where(x => x.Year.HasValue).ToArray();

        inscriptions.AddRange(GetYearlyAccomplishmentAbbreviations(items));

        return inscriptions.ToArray();
    }
}
