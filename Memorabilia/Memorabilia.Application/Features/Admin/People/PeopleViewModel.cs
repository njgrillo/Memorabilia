using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class PeopleViewModel : ViewModel
{
    public PeopleViewModel() { }

    public PeopleViewModel(IEnumerable<Person> persons)
    {
        People = persons.Select(person => new PersonViewModel(person)).ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle => AdminDomainItem.People.Item;

    public override string PageTitle => AdminDomainItem.People.Title;

    public List<PersonViewModel> People { get; set; } = new();

    public override string RoutePrefix => AdminDomainItem.People.Page;
}
