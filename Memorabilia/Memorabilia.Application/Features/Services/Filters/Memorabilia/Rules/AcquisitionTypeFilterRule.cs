namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class AcquisitionTypeFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _acquiredTypeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaAcquisitionType)
            return false;

        _acquiredTypeId = (int)value;

        return _acquiredTypeId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Acquisition.AcquisitionTypeId == _acquiredTypeId;

        return expression;
    }
}
