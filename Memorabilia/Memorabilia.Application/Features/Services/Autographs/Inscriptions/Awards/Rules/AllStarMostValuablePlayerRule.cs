using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class AllStarMostValuablePlayerRule : AwardRule, IAwardRule
{
    private Domain.Constants.AwardType _awardType;

    public override Domain.Constants.AwardType AwardType
        => _awardType;

    public override bool Applies(Domain.Constants.AwardType awardType)
    {
        _awardType = awardType;

        return awardType == Domain.Constants.AwardType.AllStarGameMostValuablePlayer ||
               awardType == Domain.Constants.AwardType.NBAAllStarGameMVP;
    }

    public string[] GenerateInscriptions(PersonAward[] awards)
    {
        var inscriptions = new List<string>()
        {
            $"{AwardType.Abbreviation}"
        };

        if (awards.Length > 1)
        {
            inscriptions.Add(GetMultipleTimeAwardAbbreviation(awards));
        }

        inscriptions.AddRange(GetYearlyAwardAbbreviations(awards));

        return inscriptions.ToArray();
    }
}
