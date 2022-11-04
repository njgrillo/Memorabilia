using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.InternationalHallOfFames;

public class InternationalHallOfFamesViewModel
{
    public InternationalHallOfFamesViewModel() { }

    public InternationalHallOfFamesViewModel(IEnumerable<InternationalHallOfFame> internationalHallOfFames)
    {
        InternationalHallOfFames = internationalHallOfFames.Select(hallOfFame => new InternationalHallOfFameViewModel(hallOfFame))
                                                           .OrderByDescending(hallOfFame => hallOfFame.InductionYear)
                                                           .ThenBy(hallOfFame => hallOfFame.PersonName);
    }

    public IEnumerable<InternationalHallOfFameViewModel> InternationalHallOfFames { get; set; } = Enumerable.Empty<InternationalHallOfFameViewModel>();

    public int InternationalHallOfFameTypeId { get; set; }

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
