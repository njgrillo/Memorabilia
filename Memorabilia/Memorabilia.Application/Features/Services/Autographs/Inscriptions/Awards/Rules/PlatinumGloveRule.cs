using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class PlatinumGloveRule : AwardRule, IAwardRule
{
    public override Domain.Constants.AwardType AwardType
        => Domain.Constants.AwardType.PlatinumGlove;

    public string[] GenerateInscriptions(PersonAward[] awards)
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
