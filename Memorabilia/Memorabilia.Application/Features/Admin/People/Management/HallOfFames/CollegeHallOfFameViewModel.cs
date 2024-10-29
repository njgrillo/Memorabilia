namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class CollegeHallOfFameViewModel
{
    private readonly Entity.CollegeHallOfFame _hallOfFame;

    public CollegeHallOfFameViewModel() { }

    public CollegeHallOfFameViewModel(Entity.CollegeHallOfFame hallOfFame)
    {
        _hallOfFame = hallOfFame;
    }

    public Constant.College College
        => Constant.College.Find(_hallOfFame.CollegeId);

    public string CollegeName
        => College?.Name;

    public int Id
        => _hallOfFame.Id;

    public int PersonId
        => _hallOfFame.PersonId;

    public Constant.Sport Sport
        => Constant.Sport.Find(_hallOfFame.SportId);

    public string SportName
        => Sport?.Name;

    public int? Year
        => _hallOfFame.Year;
}
