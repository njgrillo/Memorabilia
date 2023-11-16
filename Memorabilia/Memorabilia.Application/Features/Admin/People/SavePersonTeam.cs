namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public class SavePersonTeam
{
    public class Handler(IPersonRepository personRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person = await personRepository.Get(command.PersonId);

            if (command.DeletedTeamIds.HasAny())
                person.RemoveTeams(command.DeletedTeamIds);

            foreach (var team in command.Teams.Where(x => !x.IsDeleted))
            {
                person.SetTeam(team.Id, 
                               team.TeamId, 
                               team.BeginYear, 
                               team.EndYear, 
                               team.TeamRoleType.Id);
            }

            await personRepository.Update(person);
        }
    }

    public class Command(int personId, IEnumerable<PersonTeamEditModel> teams) 
        : DomainCommand, ICommand
    {
        public int[] DeletedTeamIds 
            => Teams.Where(team => team.IsDeleted)
                    .Select(team => team.Id)
                    .ToArray();

        public int PersonId { get; }
            = personId;

        public PersonTeamEditModel[] Teams { get; } 
            = teams.ToArray();        
    }
}
