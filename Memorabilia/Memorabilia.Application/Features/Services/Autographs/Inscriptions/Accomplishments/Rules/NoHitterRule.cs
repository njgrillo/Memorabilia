namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class NoHitterRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.NoHitter;

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>();

        if (accomplishments.Length > 1)
            inscriptions.Add(GetMultipleAccomplishmentName(accomplishments));

        inscriptions.AddRange(GetDateAccomplishmentNames(accomplishments.Where(x => x.Date.HasValue).ToArray()));

        return inscriptions.ToArray();
    }
}
