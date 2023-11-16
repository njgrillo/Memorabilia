namespace Memorabilia.Application.Services.Filters.Memorabilia.Rules;

public class TeamFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int? _teamId;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaTeam)
            return false;

        _teamId = (int?)value;

        return _teamId.HasValue && _teamId.Value > 0;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => item => item.Teams.Select(team => team.TeamId).Contains(_teamId.Value);
}
