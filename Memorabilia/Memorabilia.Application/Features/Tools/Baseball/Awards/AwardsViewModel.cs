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

    public Domain.Constants.AwardType AwardType { get; set; }

    public string AwardTypeName => AwardType?.Name;

    public IEnumerable<AwardViewModel> PersonAwards { get; set; } = Enumerable.Empty<AwardViewModel>();

    public int[] SportIds => new int[] { Domain.Constants.Sport.Baseball.Id };
}
