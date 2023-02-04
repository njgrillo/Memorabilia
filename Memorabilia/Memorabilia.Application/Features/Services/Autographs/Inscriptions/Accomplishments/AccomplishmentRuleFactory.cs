namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments;

public class AccomplishmentRuleFactory
{
    public List<IAccomplishmentRule> Rules { get; set; } = new();

    public AccomplishmentRuleFactory()
    {
        Rules.Add(new AllProRule());
        Rules.Add(new BattingTripleCrownRule());
        Rules.Add(new CombinedNoHitterRule());
        Rules.Add(new CycleRule());
        Rules.Add(new FortyFortyRule());
        Rules.Add(new FourHomeRunsRule());
        Rules.Add(new ImmaculateInningRule());
        Rules.Add(new NoHitterRule());
        Rules.Add(new PerfectGameRule());
        Rules.Add(new PitchingTripleCrownRule());
        Rules.Add(new SlamDunkContestRule());
        Rules.Add(new ThirtyThirtyRule());
        Rules.Add(new ThreePointContestRule());
        Rules.Add(new UnassistedTriplePlayRule());
    }
}
