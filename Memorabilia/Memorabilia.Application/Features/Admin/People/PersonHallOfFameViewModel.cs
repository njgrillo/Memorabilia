using Memorabilia.Domain.Entities;
using System.Collections.Generic;

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

        public int PersonId => _person.Id;
    }
}
