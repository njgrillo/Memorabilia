namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePersonImage(int PersonId, string ImageFileName) : ICommand
{
    public class Handler(IPersonRepository personRepository) 
        : CommandHandler<SavePersonImage>
    {
        protected override async Task Handle(SavePersonImage command)
        {
            Entity.Person person = await personRepository.Get(command.PersonId);

            person.SetImage(command.ImageFileName);

            await personRepository.Update(person);
        }
    }
}
