namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SizeFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _sizeIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaSize)
            return false;

        _sizeIds = (int[])value;

        return _sizeIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => _sizeIds.Contains(item.Size.SizeId);
    }
}
