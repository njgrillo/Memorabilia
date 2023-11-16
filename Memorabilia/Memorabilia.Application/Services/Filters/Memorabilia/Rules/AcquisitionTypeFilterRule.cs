namespace Memorabilia.Application.Services.Filters.Memorabilia.Rules;

public class AcquisitionTypeFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _acquisitionTypeIds;
    private FilterItemEnum _filterItem;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographAcquisitionType &&
            filterItem != FilterItemEnum.MemorabiliaAcquisitionType)
            return false;

        _acquisitionTypeIds = (int[])value;
        _filterItem = filterItem;

        return _acquisitionTypeIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    => _filterItem == FilterItemEnum.AutographAcquisitionType
        ? item => item.Autographs.Any(autograph => _acquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId))
        : item => _acquisitionTypeIds.Contains(item.Acquisition.AcquisitionTypeId);
}
