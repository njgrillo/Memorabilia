using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class FortyFortyRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Domain.Constants.AccomplishmentType AccomplishmentType
        => Domain.Constants.AccomplishmentType.FortyFortyClub;

    public string[] GenerateInscriptions(PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}",
            $"{AccomplishmentType.Name}"
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
