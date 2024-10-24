namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveAccomplishments
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            person = await personRepository.Get(command.PersonId);

            foreach (AccomplishmentEditModel accomplishment in command.Accomplishments)
            {
                person.SetAccomplishments(
                    accomplishment.Id, 
                    accomplishment.AccomplishmentType.Id,
                    accomplishment.Date,
                    accomplishment.Year
                    );
            }

            person.RemoveAccomplishments(command.DeletedAccomplishmentIds);

            await personRepository.Update(person);
        }
    }

    public class Command(AccomplishmentsEditModel editModel)
        : DomainCommand, ICommand
    {
        public AccomplishmentEditModel[] Accomplishments
            => editModel.Accomplishments
                        .Where(accomplishment => !accomplishment.IsDeleted)
                        .ToArray();

        public int[] DeletedAccomplishmentIds
            => editModel.Accomplishments
                        .Where(accomplishment => accomplishment.Id > 0 && accomplishment.IsDeleted)
                        .Select(accomplishment => accomplishment.Id)
                        .ToArray();

        public int PersonId
            => editModel.PersonId;
    }
}
