namespace Memorabilia.Application.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class FortyFortyRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.FortyFortyClub;

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
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

        Entity.PersonAccomplishment[] items = accomplishments.Where(x => x.Year.HasValue)
                                                             .ToArray();

        inscriptions.AddRange(GetYearlyAccomplishmentAbbreviations(items));
        inscriptions.AddRange(GetYearlyAccomplishmentNames(items));

        return inscriptions.ToArray();
    }
}
