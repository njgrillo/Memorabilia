namespace Memorabilia.Application.Services.Autographs.Inscriptions.Awards.Rules;

public class PlatinumGloveRule : AwardRule, IAwardRule
{
    public override Constant.AwardType AwardType
        => Constant.AwardType.PlatinumGlove;

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
