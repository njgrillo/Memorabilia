namespace Memorabilia.Application.Features.Services.Filters;

public interface IFilterPredicateBuilder<T>
{
    Expression<Func<T, bool>> Predicate { get; set; }

    void AppendPredicateAnd(FilterItemEnum filterType, object value);

    void AppendPredicateOr(FilterItemEnum filterType, object value);
}
