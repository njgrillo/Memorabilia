using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Leaders;

public class LeaderViewModel
{
    private readonly Leader _leader;

    public LeaderViewModel(Leader leader)
    {
        _leader = leader;
    }

    public int LeaderTypeId => _leader.LeaderTypeId;

    public string LeaderTypeName => Domain.Constants.LeaderType.Find(LeaderTypeId)?.Name;

    public int PersonId => _leader.PersonId;

    public string PersonImagePath => _leader.Person.ImagePath;

    public string PersonName => _leader.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Year => _leader.Year.ToString();
}
