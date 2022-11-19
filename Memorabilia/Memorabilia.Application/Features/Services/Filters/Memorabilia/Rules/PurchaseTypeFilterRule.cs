﻿namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class PurchaseTypeFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _purchaseTypeIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaPurchaseType)
            return false;

        _purchaseTypeIds = (int[])value;

        return _purchaseTypeIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => _purchaseTypeIds.Contains(item.Acquisition.PurchaseTypeId ?? 0);
    }
}
