using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonLeaderViewModel : SaveViewModel
{
    public SavePersonLeaderViewModel() { }

    public SavePersonLeaderViewModel(Leader leader)
    {
        LeaderType = Domain.Constants.LeaderType.Find(leader.LeaderTypeId);
        Id = leader.Id;
        PersonId = leader.PersonId;
        Year = leader.Year;
    }

    public Domain.Constants.LeaderType LeaderType { get; set; }

    public string LeaderTypeName => LeaderType?.Name;

    public int PersonId { get; set; }

    public int Year { get; set; }
}
