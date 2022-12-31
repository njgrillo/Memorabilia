using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public class PersonCollegesViewModel
{
    public PersonCollegesViewModel() { }

    public PersonCollegesViewModel(IEnumerable<PersonCollege> personColleges, Domain.Constants.Sport sport)
    {
        Colleges = personColleges.Select(college => new PersonCollegeViewModel(college, sport))
                                 .OrderBy(college => college.PersonName);
    }

    public Domain.Constants.College College { get; set; }

    public string CollegeName => College?.Name;

    public IEnumerable<PersonCollegeViewModel> Colleges { get; set; } = Enumerable.Empty<PersonCollegeViewModel>();

    public string ResultsTitle => $"{CollegeName} Players";
}
