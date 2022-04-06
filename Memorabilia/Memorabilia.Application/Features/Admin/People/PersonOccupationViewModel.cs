using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class PersonOccupationViewModel
    {
        private readonly PersonOccupation _personOccupation;

        public PersonOccupationViewModel() { }

        public PersonOccupationViewModel(PersonOccupation personOccupation)
        {
            _personOccupation = personOccupation;
        }

        public int Id => _personOccupation.Id;

        public int OccupationId => _personOccupation.OccupationId;

        public int OccupationTypeId => _personOccupation.OccupationTypeId;

        public int PersonId => _personOccupation.PersonId;
    }
}
