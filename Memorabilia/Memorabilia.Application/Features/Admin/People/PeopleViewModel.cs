using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People
{
    public class PeopleViewModel : ViewModel
    {
        public PeopleViewModel() { }

        public PeopleViewModel(IEnumerable<Person> persons)
        {
            People = persons.Select(person => new PersonViewModel(person)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Person";

        public override string PageTitle => "People";

        public List<PersonViewModel> People { get; set; } = new();

        public override string RoutePrefix => "People";        
    }
}
