using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class ImmaculateInningRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Domain.Constants.AccomplishmentType AccomplishmentType
        => Domain.Constants.AccomplishmentType.ImmaculateInning;

    public string[] GenerateInscriptions(PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Name}"
        };

        if (accomplishments.Length > 1)
            inscriptions.Add(GetMultipleAccomplishmentName(accomplishments));

        PersonAccomplishment[] items = accomplishments.Where(x => x.Date.HasValue).ToArray();

        inscriptions.AddRange(GetDateAccomplishmentNames(items));

        return inscriptions.ToArray();
    }
}
