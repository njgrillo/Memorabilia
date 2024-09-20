namespace Memorabilia.Application.Features.Admin.People.Management.SportServices;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveSportService
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            person = await personRepository.Get(command.PersonId);

            person.SetService(command.DebutDate, command.FreeAgentSigningDate, command.LastAppearanceDate);

            await personRepository.Update(person);
        }
    }

    public class Command(SportServiceEditModel editModel)
        : DomainCommand, ICommand
    {
        public DateTime? DebutDate
            => editModel.DebutDate;

        public DateTime? FreeAgentSigningDate
            => editModel.FreeAgentSigningDate;

        public DateTime? LastAppearanceDate
            => editModel.LastAppearanceDate;

        public int PersonId
            => editModel.PersonId;
    }
}
