using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class WorldSeriesMostValuablePlayerRule : AwardRule, IAwardRule
{
    public override Domain.Constants.AwardType AwardType
        => Domain.Constants.AwardType.WorldSeriesMostValuablePlayer;

    public string[] GenerateInscriptions(PersonAward[] awards)
    {
        var inscriptions = new List<string>()
        {
            $"{AwardType.Abbreviation}",
            $"{AwardType.Name}"
        };

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
