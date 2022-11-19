namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class EstimatedValueFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private FilterItemEnum _filterItem;
    private MudBlazor.Range<decimal?> _range;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographEstimatedValue &&
            filterItem != FilterItemEnum.MemorabiliaEstimatedValue)
            return false;

        _filterItem = filterItem;
        _range = (MudBlazor.Range<decimal?>)value;

        return _range.Start.HasValue || _range.End.HasValue;
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return _filterItem == FilterItemEnum.AutographEstimatedValue
            ? item => item.Autographs.Any(autograph => autograph.EstimatedValue >= (_range.Start ?? 0) && autograph.EstimatedValue <= (_range.End ?? decimal.MaxValue))
            : item => item.EstimatedValue >= (_range.Start ?? 0) && item.EstimatedValue <= (_range.End ?? decimal.MaxValue);
    }
}
