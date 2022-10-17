namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class BrandFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _brandId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaBrand)
            return false;

        _brandId = (int)value;

        return _brandId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.BrandId == _brandId;

        return expression;
    }
}
