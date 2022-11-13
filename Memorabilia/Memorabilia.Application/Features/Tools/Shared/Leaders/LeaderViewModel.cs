using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public class LeaderViewModel : PersonSportToolViewModel
{
    private readonly Leader _leader;

    public LeaderViewModel(Leader leader, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        _leader = leader;
        SportLeagueLevel = sportLeagueLevel;
    }

    public int LeaderTypeId => _leader.LeaderTypeId;

    public string LeaderTypeName => Domain.Constants.LeaderType.Find(LeaderTypeId)?.Name;

    public override int PersonId => _leader.PersonId;

    public override string PersonImageFileName => _leader.Person.ImageFileName;

    public override string PersonName => _leader.Person.DisplayName;

    public string Year => _leader.Year.ToString();
}
