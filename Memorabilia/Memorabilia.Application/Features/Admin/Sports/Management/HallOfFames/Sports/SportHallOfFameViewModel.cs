namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames.Sports;

public class SportHallOfFameViewModel
{
    private readonly Entity.HallOfFame[] _hallOfFamers;
    private readonly int _sportLeagueLevelId;

    public SportHallOfFameViewModel() { }

    public SportHallOfFameViewModel(int sportLeagueLevelId, Entity.HallOfFame[] hallOfFamers)
    {
        _hallOfFamers = hallOfFamers;
        _sportLeagueLevelId = sportLeagueLevelId;
    }

    public Entity.HallOfFame[] HallOfFamers
        => _hallOfFamers;

    public int SportLeageLevelId
        => _sportLeagueLevelId;
}
