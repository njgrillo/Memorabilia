namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class CollegeHallOfFamesEditModel : EditModel
{
    public CollegeHallOfFamesEditModel() { }

    public CollegeHallOfFamesEditModel(
        int collegeId,
        Entity.CollegeHallOfFame[] hallOfFames
        )
    {
        CollegeId = collegeId;
        HallOfFames = hallOfFames.Select(x => new CollegeHallOfFameEditModel(x)).ToList();
    }    

    public Constant.College College { get; set; }

    public int CollegeId { get; set; }

    public string CollegeName
        => Constant.College.Find(CollegeId)?.Name;

    public List<CollegeHallOfFameEditModel> HallOfFames { get; set; }
        = [];
}
