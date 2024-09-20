namespace Memorabilia.Application.Features.Admin.People.Management.Drafts;

public class DraftsEditModel
{
    public DraftsEditModel() { }

    public DraftsEditModel(PersonModel person)
    {
        Drafts = person.Drafts
                       .Select(x => new DraftEditModel(x))
                       .ToList();

        PersonId = person.Id;
    }

    public List<DraftEditModel> Drafts { get; set; }
        = [];

    public int PersonId { get; private set; }
}
