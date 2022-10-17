namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class AcquisitionTypeFilterRule : IFilterRule<AutographViewModel>
{
    private int _acquisitionTypeId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographAcquisitionType)
            return false;

        _acquisitionTypeId = (int)value;

        return _acquisitionTypeId > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.AcquisitionTypeId == _acquisitionTypeId;

        return expression;
    }
}
