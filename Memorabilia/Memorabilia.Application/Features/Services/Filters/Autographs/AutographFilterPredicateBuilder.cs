namespace Memorabilia.Application.Features.Services.Filters.Autographs;

public class AutographFilterPredicateBuilder : FilterPredicateBuilder<AutographViewModel>, IAutographFilterPredicateBuilder
{
    public AutographFilterPredicateBuilder(IAutographFilterRuleFactory autographFilterRuleFactory)
        : base(autographFilterRuleFactory.Rules, PredicateBuilder.True<AutographViewModel>()) { }
}
