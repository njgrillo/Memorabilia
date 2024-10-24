namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments;

public class AccomplishmentsEditModel
{
    public AccomplishmentsEditModel() { }

    public AccomplishmentsEditModel(PersonModel person)
    {
        Accomplishments = person.Accomplishments
                                .Select(x => new AccomplishmentEditModel(x))
                                .ToList();

        PersonId = person.Id;
    }

    public List<AccomplishmentEditModel> Accomplishments { get; set; }
        = [];

    public int PersonId { get; private set; }
}
