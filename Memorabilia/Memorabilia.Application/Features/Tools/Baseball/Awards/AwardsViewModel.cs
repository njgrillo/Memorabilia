using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Awards;

public class AwardsViewModel
{
    public AwardsViewModel() { }

    public AwardsViewModel(IEnumerable<PersonAward> personAwards)
    {
        PersonAwards = personAwards.Select(award => new AwardViewModel(award))
                                   .OrderByDescending(personAward => personAward.Year)
                                   .ThenBy(personAward => personAward.PersonName);
    }

    public int AwardTypeId { get; set; }

    public IEnumerable<AwardViewModel> PersonAwards { get; set; } = Enumerable.Empty<AwardViewModel>();
}
