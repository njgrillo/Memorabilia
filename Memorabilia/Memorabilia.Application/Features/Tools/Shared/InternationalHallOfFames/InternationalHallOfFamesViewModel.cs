using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public class InternationalHallOfFamesViewModel
{
    public InternationalHallOfFamesViewModel() { }

    public InternationalHallOfFamesViewModel(IEnumerable<InternationalHallOfFame> internationalHallOfFames, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        InternationalHallOfFames = internationalHallOfFames.Select(hallOfFame => new InternationalHallOfFameViewModel(hallOfFame, sportLeagueLevel))
                                                           .OrderByDescending(hallOfFame => hallOfFame.InductionYear)
                                                           .ThenBy(hallOfFame => hallOfFame.PersonName);
    }

    public IEnumerable<InternationalHallOfFameViewModel> InternationalHallOfFames { get; set; } = Enumerable.Empty<InternationalHallOfFameViewModel>();

    public int InternationalHallOfFameTypeId { get; set; }

    public string InternationalHallOfFameTypeName => Domain.Constants.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId)?.Name;

    public string ResultsTitle => $"{InternationalHallOfFameTypeName}rs";
}
