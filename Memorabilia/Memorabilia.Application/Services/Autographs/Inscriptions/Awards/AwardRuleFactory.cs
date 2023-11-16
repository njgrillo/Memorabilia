namespace Memorabilia.Application.Services.Autographs.Inscriptions.Awards;

public class AwardRuleFactory
{
    public List<IAwardRule> Rules { get; set; }
        = [];

    public AwardRuleFactory()
    {
        Rules.Add(new AllStarMostValuablePlayerRule());
        Rules.Add(new CyYoungRule());
        Rules.Add(new FinalsMostValuablePlayerRule());
        Rules.Add(new GoldGloveRule());
        Rules.Add(new ManagerOfTheYearRule());
        Rules.Add(new ManOfTheYearRule());
        Rules.Add(new MostValuablePlayerRule());
        Rules.Add(new PlatinumGloveRule());
        Rules.Add(new PlayerOfTheYearRule());
        Rules.Add(new RookieOfTheYearRule());
        Rules.Add(new SilverSluggerRule());
        Rules.Add(new SixthManRule());
        Rules.Add(new WorldSeriesMostValuablePlayerRule());
    }
}
