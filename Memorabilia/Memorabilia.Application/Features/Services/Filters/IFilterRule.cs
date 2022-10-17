namespace Memorabilia.Application.Features.Services.Filters;

public interface IFilterRule<T>
{
    bool Applies(FilterItemEnum filterItemEnum, object value);

    Expression<Func<T, bool>> GetExpression();
}
