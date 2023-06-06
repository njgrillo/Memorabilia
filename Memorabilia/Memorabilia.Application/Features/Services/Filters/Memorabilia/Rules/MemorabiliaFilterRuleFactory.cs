namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class MemorabiliaFilterRuleFactory : IMemorabiliaFilterRuleFactory
{
    public List<IFilterRule<Entity.Memorabilia>> Rules { get; set; } = new();

    public MemorabiliaFilterRuleFactory()
    {
        Rules.Add(new AcquiredDateFilterRule());
        Rules.Add(new AcquisitionTypeFilterRule());
        Rules.Add(new AuthenticationFilterRule());
        Rules.Add(new BrandFilterRule());
        Rules.Add(new ColorFilterRule());
        Rules.Add(new ConditionFilterRule());
        Rules.Add(new CostFilterRule());
        Rules.Add(new EstimatedValueFilterRule());
        Rules.Add(new FranchiseFilterRule());
        Rules.Add(new GameStyleTypeFilterRule());
        Rules.Add(new GradeFilterRule());
        Rules.Add(new ImageFilterRule());
        Rules.Add(new InscriptionFilterRule());
        Rules.Add(new ItemTypeFilterRule());
        Rules.Add(new LevelTypeFilterRule());
        Rules.Add(new PersonFilterRule());
        Rules.Add(new PrivacyTypeFilterRule());
        Rules.Add(new PurchaseTypeFilterRule());
        Rules.Add(new SizeFilterRule());
        Rules.Add(new SportFilterRule());
        Rules.Add(new SportLeagueLevelFilterRule());
        Rules.Add(new SpotFilterRule());
        Rules.Add(new TeamFilterRule());
        Rules.Add(new WritingInstrumentFilterRule());
    }
}
