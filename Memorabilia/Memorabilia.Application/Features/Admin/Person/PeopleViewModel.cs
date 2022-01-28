using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class PeopleViewModel : ViewModel
    {
        public PeopleViewModel() { }

        public PeopleViewModel(IEnumerable<Domain.Entities.Person> persons)
        {
            People = persons.Select(person => new PersonViewModel(person));
        }

        public override string PageTitle => "People";

        public IEnumerable<PersonViewModel> People { get; set; } = Enumerable.Empty<PersonViewModel>();
    }
}
