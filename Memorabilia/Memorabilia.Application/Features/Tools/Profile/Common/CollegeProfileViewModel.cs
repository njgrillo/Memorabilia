using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class CollegeProfileViewModel
{
    private readonly PersonCollege _college;

    public CollegeProfileViewModel(PersonCollege college)
    {
        _college = college;
    }

    public int? BeginYear => _college.BeginYear;

    public Domain.Constants.College College => Domain.Constants.College.Find(CollegeId);

    public string CollegeAbbreviation => College?.Abbreviation;

    public int CollegeId => _college.CollegeId;

    public string CollegeName => College?.Name;        

    public int? EndYear => _college.EndYear;

    public override string ToString()
    {
        return $"{CollegeName} ({CollegeAbbreviation}) - {BeginYear} - {EndYear}";
    }
}
