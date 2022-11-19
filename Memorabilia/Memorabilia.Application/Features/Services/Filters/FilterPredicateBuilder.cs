namespace Memorabilia.Application.Features.Services.Filters;

public abstract class FilterPredicateBuilder<T> : IFilterPredicateBuilder<T>
{
    private readonly List<IFilterRule<T>> _rules;

    public Expression<Func<T, bool>> Predicate { get; set; }

    public FilterPredicateBuilder(List<IFilterRule<T>> rules, Expression<Func<T, bool>> predicate)
    {
        _rules = rules;
        Predicate = predicate;
    }

    public virtual void AppendPredicateAnd(FilterItemEnum filterType, object value)
    {
        foreach (var rule in _rules)
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
        foreach (var rule in _rules)
        {
            if (rule.Applies(filterType, value))
            {
                Predicate = Predicate.Or(rule.GetExpression());
                break;
            }
        }
    }
}
