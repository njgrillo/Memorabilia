namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class CollegeProfileModel
{
    private readonly Entity.PersonCollege _college;

    public CollegeProfileModel(Entity.PersonCollege college)
    {
        _college = college;
    }

    public int? BeginYear 
        => _college.BeginYear;

    public Constant.College College 
        => Constant.College.Find(CollegeId);

    public string CollegeAbbreviation 
        => College?.Abbreviation;

    public int CollegeId 
        => _college.CollegeId;

    public string CollegeName 
        => College?.Name;        

    public int? EndYear
        => _college.EndYear;

    public override string ToString()
        => $"{CollegeName} ({CollegeAbbreviation}) - {BeginYear} - {EndYear}";
}
