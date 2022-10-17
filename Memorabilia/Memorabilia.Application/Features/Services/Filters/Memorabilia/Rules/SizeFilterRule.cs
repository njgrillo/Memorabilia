namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SizeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _sizeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaSize)
            return false;

        _sizeId = (int)value;

        return _sizeId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.SizeId == _sizeId;

        return expression;
    }
}
