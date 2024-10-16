namespace Memorabilia.Application.Features.Admin.Colleges.Management.RetiredNumbers;

public class CollegeRetiredNumberViewModel
{
    private readonly Entity.College _college;

    public CollegeRetiredNumberViewModel() { }

    public CollegeRetiredNumberViewModel(Entity.College college)
    {
        _college = college;
    }

    public string CollegeAbbreviation
        => _college.Abbreviation;

    public int CollegeId
        => _college.Id;

    public string CollegeName
        => _college.Name;

    public int RetiredNumberCount
        => _college.RetiredNumbers.Count;
}
