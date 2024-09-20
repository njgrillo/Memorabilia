namespace Memorabilia.Application.Features.Admin.Management.Colleges;

public class CollegeEditModel : EditModel
{
    public CollegeEditModel()
    {
        TemporaryId = Guid.NewGuid();
    }

    public CollegeEditModel(Entity.PersonCollege personCollege)
    {
        BeginYear = personCollege.BeginYear;
        College = Constant.College.Find(personCollege.CollegeId);
        EndYear = personCollege.EndYear;
        Id = personCollege.Id;
        PersonId = personCollege.PersonId;
    }

    public int? BeginYear { get; set; }

    public Constant.College College { get; set; }

    public string CollegeName
        => College?.Name;

    public int? EndYear { get; set; }

    public int PersonId { get; set; }

    public Guid? TemporaryId { get; set; }

    public void Set(Constant.College college, int? beginYear, int? endYear)
    {
        BeginYear = beginYear;
        College = college;
        EndYear = endYear;
    }

    public void Set(int id, Constant.College college, int? beginYear, int? endYear)
    {
        BeginYear = beginYear;
        College = college;
        EndYear = endYear;
        Id = id;
    }
}
