namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class BrandFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _brandIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaBrand)
            return false;

        _brandIds = (int[])value;

        return _brandIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => _brandIds.Contains(item.Brand.BrandId);
    }
}
