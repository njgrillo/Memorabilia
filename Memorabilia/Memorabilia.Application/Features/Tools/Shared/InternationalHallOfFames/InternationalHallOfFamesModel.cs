namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public class InternationalHallOfFamesModel
{
    public InternationalHallOfFamesModel() { }

    public InternationalHallOfFamesModel(IEnumerable<Entity.InternationalHallOfFame> internationalHallOfFames, 
                                         Constant.Sport sport)
    {
        InternationalHallOfFames = internationalHallOfFames.Select(hallOfFame => new InternationalHallOfFameModel(hallOfFame, sport))
                                                           .OrderByDescending(hallOfFame => hallOfFame.InductionYear)
                                                           .ThenBy(hallOfFame => hallOfFame.PersonName);
    }

    public IEnumerable<InternationalHallOfFameModel> InternationalHallOfFames { get; set; } 
        = Enumerable.Empty<InternationalHallOfFameModel>();

    public int InternationalHallOfFameTypeId { get; set; }

    public string InternationalHallOfFameTypeName 
        => Constant.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId)?.Name;

    public string ResultsTitle 
        => $"{InternationalHallOfFameTypeName}rs";
}
