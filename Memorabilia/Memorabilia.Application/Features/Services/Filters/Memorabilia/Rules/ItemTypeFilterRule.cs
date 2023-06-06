namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ItemTypeFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _itemTypeIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaItemType)
            return false;

        _itemTypeIds = (int[])value;

        return _itemTypeIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    {
        return item => _itemTypeIds.Contains(item.ItemTypeId);
    }
}
