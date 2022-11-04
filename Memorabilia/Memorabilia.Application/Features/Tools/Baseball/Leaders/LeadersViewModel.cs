using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Leaders;

public class LeadersViewModel
{
    public LeadersViewModel() { }

    public LeadersViewModel(IEnumerable<Leader> leaders)
    {
        Leaders = leaders.Select(leader => new LeaderViewModel(leader))
                         .OrderByDescending(leader => leader.Year)
                         .ThenBy(leader => leader.LeaderTypeName)
                         .ThenBy(leader => leader.PersonName);
    }

    public IEnumerable<LeaderViewModel> Leaders { get; set; } = Enumerable.Empty<LeaderViewModel>();

    public int LeaderTypeId { get; set; }

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
