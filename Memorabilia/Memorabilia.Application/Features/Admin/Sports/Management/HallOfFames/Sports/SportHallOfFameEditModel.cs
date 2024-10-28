namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames.Sports;

public class SportHallOfFameEditModel : EditModel
{
    public SportHallOfFameEditModel() { }

    public SportHallOfFameEditModel(int sportLeagueLevelId, Entity.HallOfFame[] hallOfFames)
    {
        HallOfFames = hallOfFames.Select(x => new HallOfFameEditModel(x)).ToList();
        SportLeagueLevelId = sportLeagueLevelId;
    }

    public List<HallOfFameEditModel> HallOfFames { get; set; }
        = [];

    public int SportLeagueLevelId { get; set; }

    public string SportName
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;
}
