namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class CollegeProfileModel(Entity.PersonCollege college)
{
    public int? BeginYear 
        => college.BeginYear;

    public Constant.College College 
        => Constant.College.Find(CollegeId);

    public string CollegeAbbreviation 
        => College?.Abbreviation;

    public int CollegeId 
        => college.CollegeId;

    public string CollegeName 
        => College?.Name;        

    public int? EndYear
        => college.EndYear;

    public override string ToString()
        => $"{CollegeName} ({CollegeAbbreviation}) - {BeginYear} - {EndYear}";
}
