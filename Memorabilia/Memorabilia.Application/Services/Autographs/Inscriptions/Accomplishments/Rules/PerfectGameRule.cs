namespace Memorabilia.Application.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class PerfectGameRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.PerfectGame;

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}",
            $"{AccomplishmentType.Name}"
        };

        Entity.PersonAccomplishment[] items = accomplishments.Where(x => x.Date.HasValue)
                                                             .ToArray();

        inscriptions.AddRange(GetDateAccomplishmentAbbreviations(items));
        inscriptions.AddRange(GetDateAccomplishmentNames(items));

        return inscriptions.ToArray();
    }
}
