namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ItemTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _itemTypeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaItemType)
            return false;

        _itemTypeId = (int)value;

        return _itemTypeId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.ItemTypeId == _itemTypeId;

        return expression;
    }
}
