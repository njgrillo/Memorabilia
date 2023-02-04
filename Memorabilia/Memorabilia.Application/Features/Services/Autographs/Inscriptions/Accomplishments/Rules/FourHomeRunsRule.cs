using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class FourHomeRunsRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Domain.Constants.AccomplishmentType AccomplishmentType
        => Domain.Constants.AccomplishmentType.FourHomeRunsInAGame;

    public string[] GenerateInscriptions(PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}",
            $"{AccomplishmentType.Name}"
        };

        inscriptions.AddRange(GetDateAccomplishmentAbbreviations(accomplishments.Where(x => x.Date.HasValue).ToArray()));
        inscriptions.AddRange(GetDateAccomplishmentNames(accomplishments.Where(x => x.Date.HasValue).ToArray()));

        return inscriptions.ToArray();
    }
}
