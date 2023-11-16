namespace Memorabilia.Application.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class BattingTripleCrownRule : AccomplishmentRule, IAccomplishmentRule
{
    private Constant.AccomplishmentType _accomplishmentType;

    public override Constant.AccomplishmentType AccomplishmentType
        => _accomplishmentType;

    public override bool Applies(Constant.AccomplishmentType accomplishmentType)
    {
        _accomplishmentType = accomplishmentType;

        return accomplishmentType == Constant.AccomplishmentType.AmericanLeagueTripleCrown ||
               accomplishmentType == Constant.AccomplishmentType.NationalLeagueTripleCrown;
    }

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Abbreviation}",
            $"{AccomplishmentType.Name}",
            "TC",
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
