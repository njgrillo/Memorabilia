namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class FranchiseFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _franchiseId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaFranchise)
            return false;

        _franchiseId = (int)value;

        return _franchiseId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Franchises.Select(franchise => franchise.Id).Contains(_franchiseId);

        return expression;
    }
}
