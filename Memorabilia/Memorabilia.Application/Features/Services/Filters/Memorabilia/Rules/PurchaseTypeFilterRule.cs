namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class PurchaseTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _purchaseTypeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaPurchaseType)
            return false;

        _purchaseTypeIds = (int[])value;

        return _purchaseTypeIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _purchaseTypeIds.Contains(item.PurchaseTypeId ?? 0);

        return expression;
    }
}
