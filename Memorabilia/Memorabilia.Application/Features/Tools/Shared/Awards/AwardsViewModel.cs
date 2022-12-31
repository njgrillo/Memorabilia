using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public class AwardsViewModel
{
    public AwardsViewModel() { }

    public AwardsViewModel(IEnumerable<PersonAward> personAwards, Domain.Constants.Sport sport)
    {
        PersonAwards = personAwards.Select(award => new AwardViewModel(award, sport))
                                   .OrderByDescending(personAward => personAward.Year)
                                   .ThenBy(personAward => personAward.PersonName);
    }

    public Domain.Constants.AwardType AwardType { get; set; }

    public string AwardTypeName => AwardType?.Name;

    public IEnumerable<AwardViewModel> PersonAwards { get; set; } = Enumerable.Empty<AwardViewModel>();
}
