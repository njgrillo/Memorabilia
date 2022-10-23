namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ItemTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _itemTypeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaItemType)
            return false;

        _itemTypeIds = (int[])value;

        return _itemTypeIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _itemTypeIds.Contains(item.ItemTypeId);

        return expression;
    }
}
