using MudBlazor;

namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class EstimatedValueFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private Range<decimal?> _range;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaEstimatedValue)
            return false;

        _range = (Range<decimal?>)value;

        return _range.Start.HasValue || _range.End.HasValue;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.EstimatedValue >= (_range.Start ?? 0) && item.EstimatedValue <= (_range.End ?? decimal.MaxValue);

        return expression;
    }
}
