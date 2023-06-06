namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class FranchiseFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _franchiseIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaFranchise)
            return false;

        _franchiseIds = (int[])value;

        return _franchiseIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    {
        return item => item.Teams
                           .Select(team => team.Team.Franchise)
                           .Select(franchise => franchise.Id)
                           .Any(franchiseId => _franchiseIds.Contains(franchiseId));
    }
}
