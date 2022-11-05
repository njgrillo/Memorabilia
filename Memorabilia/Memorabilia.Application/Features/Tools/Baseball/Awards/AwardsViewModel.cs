using Memorabilia.Domain.Constants;
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

    public string AwardTypeName => Domain.Constants.AwardType.Find(AwardTypeId)?.Name;

    public IEnumerable<AwardViewModel> PersonAwards { get; set; } = Enumerable.Empty<AwardViewModel>();
}
