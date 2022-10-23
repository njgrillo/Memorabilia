namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class AcquisitionTypeFilterRule : IFilterRule<AutographViewModel>
{
    private int[] _acquisitionTypeIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographAcquisitionType)
            return false;

        _acquisitionTypeIds = (int[])value;

        return _acquisitionTypeIds.Any();
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => _acquisitionTypeIds.Contains(autograph.AcquisitionTypeId);

        return expression;
    }
}
