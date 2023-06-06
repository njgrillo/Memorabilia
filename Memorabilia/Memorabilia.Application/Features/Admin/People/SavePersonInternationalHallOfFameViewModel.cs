using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonInternationalHallOfFameViewModel : EditModel
{
    public SavePersonInternationalHallOfFameViewModel() { }

    public SavePersonInternationalHallOfFameViewModel(InternationalHallOfFame hof)
    {
        Id = hof.Id;
        InternationalHallOfFameTypeId = hof.InternationalHallOfFameTypeId;
        PersonId = hof.PersonId;
        Year = hof.InductionYear;
    }

    public int InternationalHallOfFameTypeId { get; set; }

    public string InternationalHallOfFameTypeName => Constant.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId)?.Name;

    public Constant.InternationalHallOfFameType[] InternationalHallOfFameTypes => Constant.InternationalHallOfFameType.All;

    public int PersonId { get; set; }

    public int? Year { get; set; }
}
