using System.Collections;

namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public class AwardsModel
{
    public AwardsModel() { }

    public AwardsModel(IEnumerable<Entity.PersonAward> personAwards, Constant.Sport sport)
    {
        PersonAwards = personAwards.Select(award => new AwardModel(award, sport))
                                   .OrderByDescending(personAward => personAward.Year)
                                   .ThenBy(personAward => personAward.PersonName);
    }

    public Constant.AwardType AwardType { get; set; }

    public Entity.AwardExclusionYear[] AwardExclusionYears { get; set; }
        = Array.Empty<Entity.AwardExclusionYear>();

    public string AwardTypeName 
        => AwardType?.Name;

    public IEnumerable<AwardModel> PersonAwards { get; set; } 
        = Enumerable.Empty<AwardModel>();
}
