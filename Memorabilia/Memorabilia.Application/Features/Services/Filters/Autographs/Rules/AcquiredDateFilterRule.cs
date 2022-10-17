namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class AcquiredDateFilterRule : IFilterRule<AutographViewModel>
{
    private DateTime? _acquiredDate;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographAcquiredDate)
            return false;

        _acquiredDate = (DateTime?)value;

        return _acquiredDate.HasValue;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.AcquisitionDate == _acquiredDate;

        return expression;
    }
}
