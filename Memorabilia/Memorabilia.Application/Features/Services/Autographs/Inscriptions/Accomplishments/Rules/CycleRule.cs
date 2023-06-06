namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class CycleRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.HitForTheCycle;

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

        Entity.PersonAccomplishment[] items = accomplishments.Where(x => x.Date.HasValue)
                                                             .ToArray();

        inscriptions.AddRange(GetDateAccomplishmentAbbreviations(items));
        inscriptions.AddRange(GetDateAccomplishmentNames(items));

        return inscriptions.ToArray();
    }
}
