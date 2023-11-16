namespace Memorabilia.Application.Features.Services.Filters.Memorabilia;

public class MemorabiliaFilterPredicateBuilder(IMemorabiliaFilterRuleFactory memorabiliaFilterRuleFactory)
    : FilterPredicateBuilder<Entity.Memorabilia>(memorabiliaFilterRuleFactory.Rules, PredicateExtensions.True<Entity.Memorabilia>()), 
      IMemorabiliaFilterPredicateBuilder
{
}
