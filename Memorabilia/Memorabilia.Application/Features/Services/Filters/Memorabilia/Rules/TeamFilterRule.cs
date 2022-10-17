namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class TeamFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int? _teamId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaTeam)
            return false;

        _teamId = (int?)value;

        return _teamId.HasValue && _teamId.Value > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Teams.Select(team => team.TeamId).Contains(_teamId.Value);

        return expression;
    }
}
