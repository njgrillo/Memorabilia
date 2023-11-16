namespace Memorabilia.Application.Services.Filters;

public interface IFilterRule<T>
{
    bool Applies(FilterItemEnum filterItemEnum, object value);

    Expression<Func<T, bool>> GetExpression();
}
