namespace Memorabilia.Application.Features.Services.Filters.Memorabilia;

public class MemorabiliaFilterPredicateBuilder 
    : FilterPredicateBuilder<Entity.Memorabilia>, IMemorabiliaFilterPredicateBuilder
{
    public MemorabiliaFilterPredicateBuilder(IMemorabiliaFilterRuleFactory memorabiliaFilterRuleFactory)
        : base(memorabiliaFilterRuleFactory.Rules, PredicateExtensions.True<Entity.Memorabilia>()) { }
}
