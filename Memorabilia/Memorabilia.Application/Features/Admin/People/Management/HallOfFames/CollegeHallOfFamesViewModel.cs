namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class CollegeHallOfFamesViewModel
{
    private readonly int _collegeId;
    private readonly Entity.CollegeHallOfFame[] _hallOfFamers;

    public CollegeHallOfFamesViewModel() { }

    public CollegeHallOfFamesViewModel(int collegeId, Entity.CollegeHallOfFame[] hallOfFamers)
    {
        _collegeId = collegeId;
        _hallOfFamers = hallOfFamers;        
    }

    public int CollegeId
        => _collegeId;

    public Entity.CollegeHallOfFame[] HallOfFamers
        => _hallOfFamers;    
}
