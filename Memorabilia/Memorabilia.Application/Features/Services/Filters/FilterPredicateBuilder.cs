namespace Memorabilia.Application.Features.Services.Filters;

public abstract class FilterPredicateBuilder<T>(List<IFilterRule<T>> rules, Expression<Func<T, bool>> predicate) 
    : IFilterPredicateBuilder<T>
{
    public Expression<Func<T, bool>> Predicate { get; set; } 
        = predicate;

    public virtual void AppendPredicateAnd(FilterItemEnum filterType, object value)
    {
        foreach (var rule in rules)
        {
            if (rule.Applies(filterType, value))
            {
                Predicate = Predicate.And(rule.GetExpression());
                break;
            }
        }
    }

    public void AppendPredicateOr(FilterItemEnum filterType, object value)
    {
        foreach (var rule in rules)
        {
            if (rule.Applies(filterType, value))
            {
                Predicate = Predicate.Or(rule.GetExpression());
                break;
            }
        }
    }
}
