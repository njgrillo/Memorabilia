﻿namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public class ManOfTheYearRule : AwardRule, IAwardRule
{
    private Constant.AwardType _awardType;

    public override Constant.AwardType AwardType
        => _awardType;

    public override bool Applies(Constant.AwardType awardType)
    {
        _awardType = awardType;

        return awardType == Constant.AwardType.ManOfTheYear ||
               awardType == Constant.AwardType.WalterPaytonNFLManOfTheYear;
    }

    public string[] GenerateInscriptions(Entity.PersonAward[] awards)
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
