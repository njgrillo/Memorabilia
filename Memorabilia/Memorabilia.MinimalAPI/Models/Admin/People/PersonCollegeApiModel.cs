namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonCollegeApiModel
{
    private readonly Entity.PersonCollege _personCollege;

    public PersonCollegeApiModel(Entity.PersonCollege personCollege)
    {
        _personCollege = personCollege;
    }

    public int? BeginYear
        => _personCollege.BeginYear;

    public int? EndYear
        => _personCollege.EndYear;

    public string Name
        => Constant.College.Find(_personCollege.CollegeId).Name;
}
