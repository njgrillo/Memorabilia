using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class PeopleViewModel : ViewModel
    {
        public PeopleViewModel() { }

        public PeopleViewModel(IEnumerable<Domain.Entities.Person> persons)
        {
            People = persons.Select(person => new PersonViewModel(person)).ToList();
        }

        public override string ItemTitle => "Person";

        public override string PageTitle => "People";

        public List<PersonViewModel> People { get; set; } = new();

        public override string RoutePrefix => "People";        
    }
}
