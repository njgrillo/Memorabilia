namespace Memorabilia.Application.Features.Admin.People;

public class PeopleModel : Model
{
    public PeopleModel() { }

    public PeopleModel(IEnumerable<Entity.Person> persons)
    {
        People = persons.Select(person => new PersonModel(person))
                        .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle 
        => Constant.AdminDomainItem.People.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.People.Title;

    public List<PersonModel> People { get; set; } 
        = [];

    public override string RoutePrefix 
        => Constant.AdminDomainItem.People.Page;
}
