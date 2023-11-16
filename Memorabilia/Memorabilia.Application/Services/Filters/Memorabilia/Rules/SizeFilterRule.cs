namespace Memorabilia.Application.Services.Filters.Memorabilia.Rules;

public class SizeFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _sizeIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaSize)
            return false;

        _sizeIds = (int[])value;

        return _sizeIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => item => _sizeIds.Contains(item.Size.SizeId);
}
