namespace Memorabilia.Application.Features.Admin.Person
{
    public class PersonOccupationViewModel
    {
        private readonly Domain.Entities.PersonOccupation _personOccupation;

        public PersonOccupationViewModel() { }

        public PersonOccupationViewModel(Domain.Entities.PersonOccupation personOccupation)
        {
            _personOccupation = personOccupation;
        }

        public int Id => _personOccupation.Id;

        public int OccupationId => _personOccupation.OccupationId;

        public int OccupationTypeId => _personOccupation.OccupationTypeId;

        public int PersonId => _personOccupation.PersonId;
    }
}
