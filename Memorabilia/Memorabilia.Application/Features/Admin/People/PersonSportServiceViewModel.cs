using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.People
{
    public class PersonSportServiceViewModel
    {
        private readonly Person _person;

        public PersonSportServiceViewModel() { }

        public PersonSportServiceViewModel(Person person)
        {
            _person = person;
        }

        public List<PersonCollege> Colleges => _person.Colleges;

        public List<Draft> Drafts => _person.Drafts;

        public int PersonId => _person.Id;

        public SportService Service => _person.Service;

        public List<PersonSport> Sports => _person.Sports;
    }
}
