namespace Memorabilia.Application.Features.Tools.Shared.Champions;

public class ChampionsModel
{
    public ChampionsModel() { }

    public ChampionsModel(IEnumerable<Entity.Champion> champions, Constant.Sport sport)
    {
        Champions = champions.Select(champion => new ChampionModel(champion, sport));
    }

    public IEnumerable<ChampionModel> Champions { get; set; } 
        = Enumerable.Empty<ChampionModel>();
}
