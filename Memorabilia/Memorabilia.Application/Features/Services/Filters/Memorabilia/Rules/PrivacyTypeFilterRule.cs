namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class PrivacyTypeFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _privacyTypeIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaPrivacyType)
            return false;

        _privacyTypeIds = (int[])value;

        return _privacyTypeIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => _privacyTypeIds.Contains(item.PrivacyTypeId);
    }
}
