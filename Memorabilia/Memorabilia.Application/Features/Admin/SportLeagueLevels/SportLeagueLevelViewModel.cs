namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class SportLeagueLevelViewModel
{
    private readonly Entity.SportLeagueLevel _sportLeagueLevel;

    public SportLeagueLevelViewModel() { }

    public SportLeagueLevelViewModel(Entity.SportLeagueLevel sportLeagueLevel)
    {
        _sportLeagueLevel = sportLeagueLevel;
    }

    public string Abbreviation => _sportLeagueLevel.Abbreviation;

    public int Id => _sportLeagueLevel.Id;

    public int LevelTypeId => _sportLeagueLevel.LevelTypeId;

    public string LevelTypeName => _sportLeagueLevel.LevelTypeName;

    public string Name => _sportLeagueLevel.Name;

    public int SportId => _sportLeagueLevel.SportId;

    public string SportName => _sportLeagueLevel.SportName;
}
