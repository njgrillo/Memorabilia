using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonAwardViewModel : SaveViewModel
    {
        public SavePersonAwardViewModel() { }

        public SavePersonAwardViewModel(PersonAward award)
        {
            AwardTypeId = award.AwardTypeId;
            Id = award.Id;
            PersonId = award.PersonId;
            Year = award.Year;
        }

        public int AwardTypeId { get; set; }

        public string AwardTypeName => Domain.Constants.AwardType.Find(AwardTypeId)?.Name;

        public Domain.Constants.AwardType[] AwardTypes => Domain.Constants.AwardType.All;

        public int PersonId { get; set; }

        public int Year { get; set; }
    }
}
