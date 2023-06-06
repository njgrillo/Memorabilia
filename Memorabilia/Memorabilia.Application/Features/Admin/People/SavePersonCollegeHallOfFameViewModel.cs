using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCollegeHallOfFameViewModel : EditModel
{
    public SavePersonCollegeHallOfFameViewModel() { }

    public SavePersonCollegeHallOfFameViewModel(CollegeHallOfFame hof)
    {
        College = Constant.College.Find(hof.CollegeId);
        Id = hof.Id;
        PersonId = hof.PersonId;
        Sport = Constant.Sport.Find(hof.SportId);
        Year = hof.Year;
    }

    public Constant.College College { get; set; }

    public string CollegeName => College?.Name;

    public int PersonId { get; set; }

    public Constant.Sport Sport { get; set; }

    public string SportName => Sport?.Name;

    public int? Year { get; set; }
}
