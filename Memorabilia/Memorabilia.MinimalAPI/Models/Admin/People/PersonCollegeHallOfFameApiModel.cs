namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonCollegeHallOfFameApiModel
{
    private readonly Entity.CollegeHallOfFame _collegeHallOfFame;

    public PersonCollegeHallOfFameApiModel(Entity.CollegeHallOfFame collegeHallOfFame)
    {
        _collegeHallOfFame = collegeHallOfFame;
    }

    public string College
        => _collegeHallOfFame.College.Name;

    public string Sport
        => _collegeHallOfFame.Sport.Name;

    public int? Year
        => _collegeHallOfFame.Year;
}
