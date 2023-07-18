namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class AllStarMostValuablePlayerRule : AwardRule, IAwardRule
{
    private Constant.AwardType _awardType;

    public override Constant.AwardType AwardType
        => _awardType;

    public override bool Applies(Constant.AwardType awardType)
    {
        _awardType = awardType;

        return awardType == Constant.AwardType.MLBAllStarGameMostValuablePlayer ||
               awardType == Constant.AwardType.NBAAllStarGameMVP;
    }

    public string[] GenerateInscriptions(Entity.PersonAward[] awards)
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
