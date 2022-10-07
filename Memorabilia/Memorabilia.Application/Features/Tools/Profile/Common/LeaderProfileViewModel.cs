using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class LeaderProfileViewModel
{
    private readonly Leader _leader;

    public LeaderProfileViewModel(Leader leader)
    {
        _leader = leader;
    }

    public Domain.Constants.LeaderType LeaderType => Domain.Constants.LeaderType.Find(LeaderTypeId);

    public string LeaderTypeAbbreviatedName => LeaderType?.ToString();

    public int LeaderTypeId => _leader.LeaderTypeId;

    public string LeaderTypeName => LeaderType?.Name;

    public int Year => _leader.Year;
}
