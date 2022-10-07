namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonImage
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
            var person = await _personRepository.Get(command.PersonId);

            person.SetImage(command.ImagePath);

            await _personRepository.Update(person);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        public Command(SavePersonImageViewModel viewModel)
        {
            PersonId = viewModel.PersonId;
            ImagePath = viewModel.ImagePath;
        }

        public string ImagePath { get; }

        public int PersonId { get; }
    }
}
