namespace Memorabilia.Application.Services.Filters.Memorabilia.Rules;

public class BrandFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _brandIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaBrand)
            return false;

        _brandIds = (int[])value;

        return _brandIds.Length != 0;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => item => _brandIds.Contains(item.Brand.BrandId);
}
