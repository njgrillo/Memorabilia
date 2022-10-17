namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class AcquiredDateFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private DateTime? _acquiredDate;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaAcquiredDate)
            return false;

        _acquiredDate = (DateTime?)value;

        return _acquiredDate.HasValue;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Acquisition.AcquiredDate == _acquiredDate;

        return expression;
    }
}
