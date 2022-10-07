using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonLeaderViewModel : SaveViewModel
{
    public SavePersonLeaderViewModel() { }

    public SavePersonLeaderViewModel(Leader leader)
    {
        LeaderTypeId = leader.LeaderTypeId;
        Id = leader.Id;
        PersonId = leader.PersonId;
        Year = leader.Year;
    }

    public int LeaderTypeId { get; set; }

    public string LeaderTypeName => Domain.Constants.LeaderType.Find(LeaderTypeId)?.Name;

    public Domain.Constants.LeaderType[] LeaderTypes => Domain.Constants.LeaderType.All;

    public int PersonId { get; set; }

    public int Year { get; set; }
}
