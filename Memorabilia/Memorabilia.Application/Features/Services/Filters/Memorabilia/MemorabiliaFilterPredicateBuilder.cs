namespace Memorabilia.Application.Features.Services.Filters.Memorabilia;

public class MemorabiliaFilterPredicateBuilder : FilterPredicateBuilder<MemorabiliaItemViewModel>, IMemorabiliaFilterPredicateBuilder
{
    public MemorabiliaFilterPredicateBuilder(IMemorabiliaFilterRuleFactory memorabiliaFilterRuleFactory)
        : base(memorabiliaFilterRuleFactory.Rules, PredicateBuilder.True<MemorabiliaItemViewModel>()) { }
}
