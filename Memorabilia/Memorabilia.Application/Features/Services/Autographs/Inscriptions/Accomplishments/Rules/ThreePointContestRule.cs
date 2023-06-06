namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class ThreePointContestRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType 
        => Constant.AccomplishmentType.NBAThreePointContestChampion;

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}"
        };

        if (accomplishments.Length > 1)
        {
            inscriptions.Add(GetMultipleTimeAccomplishmentAbbreviation(accomplishments));
        }

        Entity.PersonAccomplishment[] items = accomplishments.Where(x => x.Year.HasValue)
                                                             .ToArray();

        inscriptions.AddRange(GetYearlyAccomplishmentAbbreviations(items));

        return inscriptions.ToArray();
    }
}
