namespace Memorabilia.Application.Services.Autographs.Inscriptions.Awards.Rules;

public class SixthManRule : AwardRule, IAwardRule
{
    public override Constant.AwardType AwardType
        => Constant.AwardType.NBASixthManOfTheYear;

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
