namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public class SavePersonTeam
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.Person person = await _personRepository.Get(command.PersonId);

            if (command.DeletedTeamIds.Any())
                person.RemoveTeams(command.DeletedTeamIds);

            foreach (var team in command.Teams.Where(x => !x.IsDeleted))
            {
                person.SetTeam(team.Id, 
                               team.TeamId, 
                               team.BeginYear, 
                               team.EndYear, 
                               team.TeamRoleType.Id);
            }

            await _personRepository.Update(person);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        public Command(int personId, IEnumerable<PersonTeamEditModel> teams)
        {
            PersonId = personId;
            Teams = teams.ToArray();
        }

        public int[] DeletedTeamIds 
            => Teams.Where(team => team.IsDeleted)
                    .Select(team => team.Id)
                    .ToArray();

        public PersonTeamEditModel[] Teams { get; }

        public int PersonId { get; }
    }
}
