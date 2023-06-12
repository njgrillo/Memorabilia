namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public class PersonCollegesModel
{
    public PersonCollegesModel() { }

    public PersonCollegesModel(IEnumerable<Entity.PersonCollege> personColleges, Constant.Sport sport)
    {
        Colleges = personColleges.Select(college => new PersonCollegeModel(college, sport))
                                 .OrderBy(college => college.PersonName);
    }

    public Constant.College College { get; set; }

    public string CollegeName 
        => College?.Name;

    public IEnumerable<PersonCollegeModel> Colleges { get; set; } 
        = Enumerable.Empty<PersonCollegeModel>();

    public string ResultsTitle 
        => $"{CollegeName} Players";
}
