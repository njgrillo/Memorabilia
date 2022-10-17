namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class EstimatedValueFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private decimal? _estimatedValue;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaEstimatedValue)
            return false;

        _estimatedValue = (decimal?)value;

        return _estimatedValue.HasValue && _estimatedValue.Value > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.EstimatedValue == _estimatedValue;

        return expression;
    }
}
