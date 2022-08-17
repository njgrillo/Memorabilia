using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.People
{
    public class PersonTeamsViewModel
    {
        private readonly Person _person;

        public PersonTeamsViewModel() { }

        public PersonTeamsViewModel(Person person)
        {
            _person = person;
        }

        public int PersonId => _person.Id;

        public List<PersonSport> Sports => _person.Sports;

        public List<PersonTeam> Teams => _person.Teams;
    }
}
