using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class CombinedNoHitterRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Domain.Constants.AccomplishmentType AccomplishmentType
        => Domain.Constants.AccomplishmentType.CombinedNoHitter;

    public string[] GenerateInscriptions(PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>();

        if (accomplishments.Length > 1)
            inscriptions.Add(GetMultipleAccomplishmentName(accomplishments));

        inscriptions.AddRange(GetDateAccomplishmentNames(accomplishments.Where(x => x.Date.HasValue).ToArray()));

        return inscriptions.ToArray();
    }
}
