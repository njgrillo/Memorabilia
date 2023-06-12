namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class CostFilterRule : IFilterRule<Entity.Memorabilia>
{
    private FilterItemEnum _filterItem;
    private MudBlazor.Range<decimal?> _range;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographCost &&
            filterItem != FilterItemEnum.MemorabiliaCost)
            return false;

        _filterItem = filterItem;
        _range = (MudBlazor.Range<decimal?>)value;

        return _range.Start.HasValue || _range.End.HasValue;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => _filterItem == FilterItemEnum.AutographCost 
            ? item => item.Autographs.Any(autograph => autograph.Acquisition.Cost >= (_range.Start ?? 0) && autograph.Acquisition.Cost <= (_range.End ?? decimal.MaxValue)) 
            : item => item.Acquisition.Cost >= (_range.Start ?? 0) && item.Acquisition.Cost <= (_range.End ?? decimal.MaxValue);
}
