namespace Memorabilia.Application.Features.Admin.People.Management.Teams;

public class PersonTeamsManagementEditModel
{
    public PersonTeamsManagementEditModel() { }

    public PersonTeamsManagementEditModel(PersonModel person)
    {
        PersonTeams = person.Teams
                            .Select(x => new PersonTeamManagementEditModel(x))
                            .ToList();

        PersonId = person.Id;
    }

    public int PersonId { get; private set; }

    public List<PersonTeamManagementEditModel> PersonTeams { get; set; }
        = [];    
}
