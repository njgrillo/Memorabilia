namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class AcquiredDateFilterRule : IFilterRule<Entity.Memorabilia>
{
    private FilterItemEnum _filterItem;
    private DateTime? _acquiredDate;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographAcquiredDate &&
            filterItem != FilterItemEnum.MemorabiliaAcquiredDate)
            return false;

        _filterItem = filterItem;
        _acquiredDate = (DateTime?)value;

        return _acquiredDate.HasValue;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => _filterItem == FilterItemEnum.AutographAcquiredDate
            ? item => item.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate == _acquiredDate)
            : item => item.Acquisition.AcquiredDate == _acquiredDate;
}
