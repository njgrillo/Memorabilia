using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public class LeadersModel
{
    public LeadersModel() { }

    public LeadersModel(IEnumerable<Leader> leaders, Constant.Sport sport)
    {
        Leaders = leaders.Select(leader => new LeaderModel(leader, sport))
                         .OrderByDescending(leader => leader.Year)
                         .ThenBy(leader => leader.LeaderTypeName)
                         .ThenBy(leader => leader.PersonName);
    }

    public IEnumerable<LeaderModel> Leaders { get; set; } = Enumerable.Empty<LeaderModel>();

    public Constant.LeaderType LeaderType { get; set; }

    public string LeaderTypeName => LeaderType?.Name;

    public string ResultsTitle => $"{LeaderTypeName} Leaders";
}
