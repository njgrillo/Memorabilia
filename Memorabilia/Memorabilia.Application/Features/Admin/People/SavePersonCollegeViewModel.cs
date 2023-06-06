using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCollegeViewModel : EditModel
{
    public SavePersonCollegeViewModel() { }

    public SavePersonCollegeViewModel(PersonCollege college)
    {
        BeginYear = college.BeginYear;
        College = Constant.College.Find(college.CollegeId);
        EndYear = college.EndYear;
        Id = college.Id;
        PersonId = college.PersonId;
    }        

    public int? BeginYear { get; set; }

    public Constant.College College { get; set; }

    public string CollegeName => College?.Name;

    public int? EndYear { get; set; }

    public int PersonId { get; set; }
}
