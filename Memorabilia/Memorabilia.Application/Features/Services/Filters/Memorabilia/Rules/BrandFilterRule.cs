namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class BrandFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _brandIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaBrand)
            return false;

        _brandIds = (int[])value;

        return _brandIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _brandIds.Contains(item.BrandId ?? 0);

        return expression;
    }
}
