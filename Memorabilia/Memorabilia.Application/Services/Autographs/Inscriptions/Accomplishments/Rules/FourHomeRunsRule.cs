namespace Memorabilia.Application.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class FourHomeRunsRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.FourHomeRunsInAGame;

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
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
