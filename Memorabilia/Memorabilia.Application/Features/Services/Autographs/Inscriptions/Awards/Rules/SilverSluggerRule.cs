namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class SilverSluggerRule : AwardRule, IAwardRule
{
    public override Constant.AwardType AwardType
        => Constant.AwardType.SilverSlugguer;

    public string[] GenerateInscriptions(Entity.PersonAward[] awards)
    {
        var inscriptions = new List<string>();

        if (awards.Length > 1)
        {
            inscriptions.Add(GetMultipleTimeAwardAbbreviation(awards));
            inscriptions.Add(GetMultipleTimeAwardName(awards));
        }

        inscriptions.AddRange(GetYearlyAwardAbbreviations(awards));
        inscriptions.AddRange(GetYearlyAwardNames(awards));

        return inscriptions.ToArray();
    }
}

