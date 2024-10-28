namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames;

public class SportHallOfFamesViewModel
{
    private readonly Entity.HallOfFame[] _hallOfFamers;
    private readonly int _sportLeagueLevelId;

    public SportHallOfFamesViewModel() { }

    public SportHallOfFamesViewModel(int sportLeagueLevelId, Entity.HallOfFame[] hallOfFamers)
    {
        _hallOfFamers = hallOfFamers;
        _sportLeagueLevelId = sportLeagueLevelId;
    }

    public Entity.HallOfFame[] HallOfFamers
        => _hallOfFamers;

    public int SportLeageLevelId
        => _sportLeagueLevelId;
}
