using System;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class PersonViewModel
    {
        private readonly Domain.Entities.Person _person;

        public PersonViewModel() { }

        public PersonViewModel(Domain.Entities.Person person)
        {
            _person = person;
        }

        public DateTime? BirthDate => _person.BirthDate;

        public DateTime? DeathDate => _person.DeathDate;

        public string FirstName => _person.FirstName;

        public string FullName => _person.FullName;

        public int Id => _person.Id;

        public string ImagePath => _person.ImagePath;

        public DateTime? LastModifiedDate => _person.LastModifiedDate;

        public string LastName => _person.LastName; 

        public string Nickname => _person.Nickname;

        public string Suffix => _person.Suffix;
    }
}
