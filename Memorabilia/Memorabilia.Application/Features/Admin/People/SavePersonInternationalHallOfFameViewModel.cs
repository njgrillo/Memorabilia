using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonInternationalHallOfFameViewModel : SaveViewModel
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

        public string InternationalHallOfFameTypeName => Domain.Constants.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId)?.Name;

        public Domain.Constants.InternationalHallOfFameType[] InternationalHallOfFameTypes => Domain.Constants.InternationalHallOfFameType.All;

        public int PersonId { get; set; }

        public int? Year { get; set; }
    }
}
