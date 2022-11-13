using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public class LeadersViewModel
{
    public LeadersViewModel() { }

    public LeadersViewModel(IEnumerable<Leader> leaders, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        Leaders = leaders.Select(leader => new LeaderViewModel(leader, sportLeagueLevel))
                         .OrderByDescending(leader => leader.Year)
                         .ThenBy(leader => leader.LeaderTypeName)
                         .ThenBy(leader => leader.PersonName);
    }

    public IEnumerable<LeaderViewModel> Leaders { get; set; } = Enumerable.Empty<LeaderViewModel>();

    public Domain.Constants.LeaderType LeaderType { get; set; }

    public string LeaderTypeName => LeaderType?.Name;

    public string ResultsTitle => $"{LeaderTypeName} Leaders";
}
