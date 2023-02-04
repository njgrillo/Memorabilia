using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class PlayerOfTheYearRule : AwardRule, IAwardRule
{
    private Domain.Constants.AwardType _awardType;

    public override Domain.Constants.AwardType AwardType
        => _awardType;

    public override bool Applies(Domain.Constants.AwardType awardType)
    {
        _awardType = awardType;

        return awardType == Domain.Constants.AwardType.DefensivePlayerOfTheYear ||
               awardType == Domain.Constants.AwardType.OffensivePlayerOfTheYear;
    }

    public string[] GenerateInscriptions(PersonAward[] awards)
    {
        var inscriptions = new List<string>
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
