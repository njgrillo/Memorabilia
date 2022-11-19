namespace Memorabilia.Application.Features.Services.Filters.Memorabilia;

public class MemorabiliaFilterPredicateBuilder : FilterPredicateBuilder<Domain.Entities.Memorabilia>, IMemorabiliaFilterPredicateBuilder
{
    public MemorabiliaFilterPredicateBuilder(IMemorabiliaFilterRuleFactory memorabiliaFilterRuleFactory)
        : base(memorabiliaFilterRuleFactory.Rules, PredicateExtensions.True<Domain.Entities.Memorabilia>()) { }
}
