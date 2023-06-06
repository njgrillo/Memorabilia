namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class UnassistedTriplePlayRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType 
        => Constant.AccomplishmentType.UnassistedTriplePlay;

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
