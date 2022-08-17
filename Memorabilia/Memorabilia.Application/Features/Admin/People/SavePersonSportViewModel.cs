using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonSportViewModel : SaveViewModel
    {
        public SavePersonSportViewModel() { }

        public SavePersonSportViewModel(PersonSport sport)
        {
            Id = sport.Id;
            PersonId = sport.PersonId;
            SportId = sport.SportId;
        }

        public int PersonId { get; set; }

        public int SportId { get; set; }

        public string SportName => Domain.Constants.Sport.Find(SportId)?.Name;

        public Domain.Constants.Sport[] Sports => Domain.Constants.Sport.All;
    }
}
