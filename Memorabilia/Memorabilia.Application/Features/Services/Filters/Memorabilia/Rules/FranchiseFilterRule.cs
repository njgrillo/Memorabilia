namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class FranchiseFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _franchiseIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaFranchise)
            return false;

        _franchiseIds = (int[])value;

        return _franchiseIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Franchises.Select(franchise => franchise.Id).Any(franchiseId => _franchiseIds.Contains(franchiseId));

        return expression;
    }
}
