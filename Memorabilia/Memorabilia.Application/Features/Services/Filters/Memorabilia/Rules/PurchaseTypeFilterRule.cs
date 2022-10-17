namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class PurchaseTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _purchaseTypeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaPurchaseType)
            return false;

        _purchaseTypeId = (int)value;

        return _purchaseTypeId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.PurchaseTypeId == _purchaseTypeId;

        return expression;
    }
}
