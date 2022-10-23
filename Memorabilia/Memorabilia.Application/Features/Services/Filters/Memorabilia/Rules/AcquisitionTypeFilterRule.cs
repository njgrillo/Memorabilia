namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class AcquisitionTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _acquiredTypeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaAcquisitionType)
            return false;

        _acquiredTypeIds = (int[])value;

        return _acquiredTypeIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => _acquiredTypeIds.Contains(item.Acquisition.AcquisitionTypeId);

        return expression;
    }
}
