namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class FranchiseFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _franchiseIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaFranchise)
            return false;

        _franchiseIds = (int[])value;

        return _franchiseIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Teams
                           .Select(team => team.Team.Franchise)
                           .Select(franchise => franchise.Id)
                           .Any(franchiseId => _franchiseIds.Contains(franchiseId));
    }
}
