using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class UnassistedTriplePlayRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Domain.Constants.AccomplishmentType AccomplishmentType
        => Domain.Constants.AccomplishmentType.UnassistedTriplePlay;

    public string[] GenerateInscriptions(PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}",
            $"{AccomplishmentType.Name}"
        };

        PersonAccomplishment[] items = accomplishments.Where(x => x.Date.HasValue).ToArray();

        inscriptions.AddRange(GetDateAccomplishmentAbbreviations(items));
        inscriptions.AddRange(GetDateAccomplishmentNames(items));

        return inscriptions.ToArray();
    }
}
