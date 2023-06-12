namespace Memorabilia.Application.Features.Admin.People;

public record SavePersonImage(int PersonId, string ImageFileName) : ICommand
{
    public class Handler : CommandHandler<SavePersonImage>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task Handle(SavePersonImage command)
        {
            Entity.Person person = await _personRepository.Get(command.PersonId);

            person.SetImage(command.ImageFileName);

            await _personRepository.Update(person);
        }
    }
}
