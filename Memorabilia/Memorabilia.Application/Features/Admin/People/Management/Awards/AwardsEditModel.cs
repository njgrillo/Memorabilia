namespace Memorabilia.Application.Features.Admin.People.Management.Awards;

public class AwardsEditModel
{
    public AwardsEditModel() { }

    public AwardsEditModel(PersonModel person)
    {
        Awards = person.Awards
                       .Select(x => new AwardEditModel(x))
                       .ToList();

        PersonId = person.Id;
    }

    public List<AwardEditModel> Awards { get; set; }
        = [];

    public int PersonId { get; private set; }
}
