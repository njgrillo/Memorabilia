namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class AutographFilterRuleFactory : IAutographFilterRuleFactory
{
    public List<IFilterRule<AutographViewModel>> Rules { get; set; } = new();

    public AutographFilterRuleFactory()
    {
        Rules.Add(new AcquiredDateFilterRule());
        Rules.Add(new AcquisitionTypeFilterRule());
        Rules.Add(new AuthenticationFilterRule());
        Rules.Add(new ColorFilterRule());
        Rules.Add(new ConditionFilterRule());
        Rules.Add(new CostFilterRule());
        Rules.Add(new EstimatedValueFilterRule());
        Rules.Add(new GradeFilterRule());
        Rules.Add(new ImageFilterRule());
        Rules.Add(new InscriptionFilterRule());
        Rules.Add(new PersonFilterRule());
        Rules.Add(new SpotFilterRule());
        Rules.Add(new WritingInstrumentFilterRule());
    }    
}
