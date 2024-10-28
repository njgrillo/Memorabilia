namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames;

public class SportHallOfFamesEditModel : EditModel
{
    public SportHallOfFamesEditModel() { }

    public SportHallOfFamesEditModel(int sportLeagueLevelId, Entity.HallOfFame[] hallOfFames)
    {
        HallOfFames = hallOfFames.Select(x => new SportHallOfFameEditModel(x)).ToList();
        SportLeagueLevelId = sportLeagueLevelId;
    }

    public List<SportHallOfFameEditModel> HallOfFames { get; set; }
        = [];

    public int SportLeagueLevelId { get; set; }

    public string SportName
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;
}
