namespace Memorabilia.Application.Features.Admin.People;

public class PersonCollegeEditModel : EditModel
{
    public PersonCollegeEditModel() { }

    public PersonCollegeEditModel(Entity.PersonCollege college)
    {
        BeginYear = college.BeginYear;
        College = Constant.College.Find(college.CollegeId);
        EndYear = college.EndYear;
        Id = college.Id;
        PersonId = college.PersonId;
    }        

    public int? BeginYear { get; set; }

    public Constant.College College { get; set; }

    public string CollegeName 
        => College?.Name;

    public int? EndYear { get; set; }

    public int PersonId { get; set; }
}
