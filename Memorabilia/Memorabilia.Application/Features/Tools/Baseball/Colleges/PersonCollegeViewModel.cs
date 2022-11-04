using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Colleges;

public class PersonCollegeViewModel
{
    private readonly PersonCollege _personCollege;

    public PersonCollegeViewModel(PersonCollege personCollege)
    {
        _personCollege = personCollege;
    }    

    public string BeginYear => _personCollege.BeginYear.HasValue ? _personCollege.BeginYear.ToString() : string.Empty;

    public int CollegeId => _personCollege.CollegeId;

    public string CollegeName => Domain.Constants.College.Find(CollegeId)?.Name;

    public string EndYear => _personCollege.EndYear.HasValue ? _personCollege.EndYear.ToString() : string.Empty;

    public int PersonId => _personCollege.PersonId;

    public string PersonImagePath => _personCollege.Person.ImagePath;

    public string PersonName => _personCollege.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";    
}
