namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SizeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _sizeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaSize)
            return false;

        _sizeIds = (int[])value;

        return _sizeIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _sizeIds.Contains(item.SizeId ?? 0);

        return expression;
    }
}
