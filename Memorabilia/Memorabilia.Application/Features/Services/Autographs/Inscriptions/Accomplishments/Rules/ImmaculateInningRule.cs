namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public class ImmaculateInningRule : AccomplishmentRule, IAccomplishmentRule
{
    public override Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.ImmaculateInning;

    public string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments)
    {
        var inscriptions = new List<string>
        {
            $"{AccomplishmentType.Name}"
        };

        if (accomplishments.Length > 1)
            inscriptions.Add(GetMultipleAccomplishmentName(accomplishments));

        Entity.PersonAccomplishment[] items = accomplishments.Where(x => x.Date.HasValue)
                                                             .ToArray();

        inscriptions.AddRange(GetDateAccomplishmentNames(items));

        return inscriptions.ToArray();
    }
}
