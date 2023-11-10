namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public class PersonCollegeModel : PersonSportToolModel
{
    private readonly Entity.PersonCollege _personCollege;

    public PersonCollegeModel(Entity.PersonCollege personCollege, Constant.Sport sport)
    {
        _personCollege = personCollege;
        Sport = sport;
    }    

    public string BeginYear 
        => _personCollege.BeginYear.HasValue 
        ? _personCollege.BeginYear.ToString() 
        : string.Empty;

    public int CollegeId 
        => _personCollege.CollegeId;

    public string CollegeName
        => Constant.College.Find(CollegeId)?.Name;

    public string EndYear 
        => _personCollege.EndYear.HasValue 
        ? _personCollege.EndYear.ToString() 
        : string.Empty;

    public override int PersonId 
        => _personCollege.PersonId;

    public override string PersonImageFileName 
        => _personCollege.Person.ImageFileName;

    public override string PersonName 
        => _personCollege.Person.ProfileName;
}
