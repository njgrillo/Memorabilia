namespace Memorabilia.Application.Features.Admin.People.Management.Teams;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveTeams
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            person = await personRepository.Get(command.PersonId);

            foreach (PersonTeamManagementEditModel personTeam in command.PersonTeams)
            {
                person.SetTeam(
                    personTeam.Id, 
                    personTeam.Team.TeamId, 
                    personTeam.BeginYear, 
                    personTeam.EndYear, 
                    personTeam.TeamRoleType.Id
                    );
            }

            person.RemoveTeams(command.DeletedTeamIds);

            await personRepository.Update(person);
        }
    }

    public class Command(PersonTeamsManagementEditModel editModel)
        : DomainCommand, ICommand
    {
        public int[] DeletedTeamIds
            => editModel.PersonTeams
                        .Where(personTeam => personTeam.Id > 0 && personTeam.IsDeleted)
                        .Select(personTeam => personTeam.Id)
                        .ToArray();

        public PersonTeamManagementEditModel[] PersonTeams
            => editModel.PersonTeams
                        .Where(personTeam => !personTeam.IsDeleted)
                        .ToArray();

        public int PersonId
            => editModel.PersonId;
    }
}
