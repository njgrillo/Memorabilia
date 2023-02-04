using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class FinalsMostValuablePlayerRule : AwardRule, IAwardRule
{
    public override Domain.Constants.AwardType AwardType
        => Domain.Constants.AwardType.FinalsMostValuablePlayer;

    public string[] GenerateInscriptions(PersonAward[] awards)
    {
        var inscriptions = new List<string>()
        {
            $"{AwardType.Name}"
        };

        if (awards.Length > 1)
        {
            inscriptions.Add(GetMultipleTimeAwardAbbreviation(awards));
        }

        inscriptions.AddRange(GetYearlyAwardAbbreviations(awards));

        return inscriptions.ToArray();
    }
}
