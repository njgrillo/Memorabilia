namespace Memorabilia.Application.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class CombinedNoHitterRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.CombinedNoHitter;

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>();

        if (accomplishments.Length > 1)
            inscriptions.Add(GetMultipleAccomplishmentName(accomplishments));

        inscriptions.AddRange(GetDateAccomplishmentNames(accomplishments.Where(x => x.Date.HasValue).ToArray()));

        return inscriptions.ToArray();
    }
}
