namespace Memorabilia.Application.Features.Admin.Management.Nicknames;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveNicknames
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            person = await personRepository.Get(command.PersonId);

            person.SetNicknames(command.Nicknames);    
            person.RemoveNicknames(command.DeletedNicknameIds);

            await personRepository.Update(person);
        }
    }

    public class Command(NicknamesEditModel editModel)
        : DomainCommand, ICommand
    {
        public int[] DeletedNicknameIds
            => editModel.Nicknames
                        .Where(nickname => nickname.Id > 0 && nickname.IsDeleted)
                        .Select(nickname => nickname.Id)
                        .ToArray();

        public string[] Nicknames
            => editModel.Nicknames
                        .Where(nickname => !nickname.IsDeleted)
                        .Select(nickname => nickname.Nickname)
                        .ToArray();

        public int PersonId
            => editModel.PersonId;        
    }
}
