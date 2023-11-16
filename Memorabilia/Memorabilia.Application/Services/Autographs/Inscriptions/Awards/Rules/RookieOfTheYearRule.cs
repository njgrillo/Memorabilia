namespace Memorabilia.Application.Services.Autographs.Inscriptions.Awards.Rules;

public class RookieOfTheYearRule : AwardRule, IAwardRule
{
    private Constant.AwardType _awardType;

    public override Constant.AwardType AwardType
        => _awardType;

    public override bool Applies(Constant.AwardType awardType)
    {
        _awardType = awardType;

        return awardType == Constant.AwardType.AmericanLeagueRookieOfTheYear ||
               awardType == Constant.AwardType.NBARookieOfTheYear ||
               awardType == Constant.AwardType.NationalLeagueRookieOfTheYear ||
               awardType == Constant.AwardType.SportingNewsNFLRookieOfTheYear;
    }

    public string[] GenerateInscriptions(Entity.PersonAward[] awards)
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
