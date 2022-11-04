using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Colleges;

public class PersonCollegesViewModel
{
    public PersonCollegesViewModel() { }

    public PersonCollegesViewModel(IEnumerable<PersonCollege> personColleges)
    {
        Colleges = personColleges.Select(college => new PersonCollegeViewModel(college))
                                 .OrderBy(college => college.PersonName);
    }

    public int CollegeId { get; set; }

    public IEnumerable<PersonCollegeViewModel> Colleges { get; set; } = Enumerable.Empty<PersonCollegeViewModel>();

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
