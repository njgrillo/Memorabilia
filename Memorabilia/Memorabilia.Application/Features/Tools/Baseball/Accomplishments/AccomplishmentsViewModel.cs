using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Accomplishments
{
    public class AccomplishmentsViewModel
    {
        public AccomplishmentsViewModel() { }

        public AccomplishmentsViewModel(IEnumerable<PersonAccomplishment> personAccomplishments)
        {
            PersonAccomplishments = personAccomplishments.Select(accomplishment => new AccomplishmentViewModel(accomplishment));
        }

        public int AccomplishmentTypeId { get; set; }

        public Domain.Constants.AccomplishmentType[] AccomplishmentTypes => Domain.Constants.AccomplishmentType.GetAll(Domain.Constants.Sport.Baseball.Id);

        public IEnumerable<AccomplishmentViewModel> PersonAccomplishments { get; set; } = Enumerable.Empty<AccomplishmentViewModel>();
    }
}
