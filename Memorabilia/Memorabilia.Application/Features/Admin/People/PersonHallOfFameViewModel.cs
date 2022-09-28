using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class PersonHallOfFameViewModel
    {
        private readonly Person _person;

        public PersonHallOfFameViewModel() { }

        public PersonHallOfFameViewModel(Person person)
        {
            _person = person;
        }

        public List<FranchiseHallOfFame> FranchiseHallOfFames => _person.FranchiseHallOfFames;

        public List<HallOfFame> HallOfFames => _person.HallOfFames;

        public List<InternationalHallOfFame> InternationalHallOfFames => _person.InternationalHallOfFames;

        public int PersonId => _person.Id;

        public List<PersonSport> Sports => _person.Sports;  
    }
}
