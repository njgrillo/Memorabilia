using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.HallOfFamers;

public class HallOfFamesModel
{
    public HallOfFamesModel() { }

    public HallOfFamesModel(IEnumerable<HallOfFame> hallOfFames, Constant.Sport sport)
    {
        HallOfFames = hallOfFames.Select(hallOfFame => new HallOfFameModel(hallOfFame, sport))
                                 .OrderBy(hallOfFame => hallOfFame.InductionYear)
                                 .ThenBy(hallOfFame => hallOfFame.PersonName);
    }

    public IEnumerable<HallOfFameModel> HallOfFames { get; set; } = Enumerable.Empty<HallOfFameModel>();

    public int InductionYear { get; set; }

    public string ResultsTitle => $"{(InductionYear > 0 ? InductionYear : string.Empty)} Hall of Famers";
}
