using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class RookieOfTheYearRule : AwardRule, IAwardRule
{
    private Domain.Constants.AwardType _awardType;

    public override Domain.Constants.AwardType AwardType
        => _awardType;

    public override bool Applies(Domain.Constants.AwardType awardType)
    {
        _awardType = awardType;

        return awardType == Domain.Constants.AwardType.AmericanLeagueRookieOfTheYear ||
               awardType == Domain.Constants.AwardType.NBARookieOfTheYear ||
               awardType == Domain.Constants.AwardType.NationalLeagueRookieOfTheYear ||
               awardType == Domain.Constants.AwardType.RookieOfTheYear;
    }

    public string[] GenerateInscriptions(PersonAward[] awards)
    {
        var inscriptions = new List<string>
        {
            $"{AwardType.Abbreviation}",
            $"{AwardType.Name}"
        };

        inscriptions.AddRange(GetYearlyAwardAbbreviations(awards));
        inscriptions.AddRange(GetYearlyAwardNames(awards));

        return inscriptions.ToArray();
    }
}
