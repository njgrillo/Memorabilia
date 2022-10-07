using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public class SaveOrientation
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Orientation> _orientationRepository;

        public Handler(IDomainRepository<Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task Handle(Command command)
        {
            Orientation orientation;

            if (command.IsNew)
            {
                orientation = new Orientation(command.Name, command.Abbreviation);

                await _orientationRepository.Add(orientation);

                return;
            }

            orientation = await _orientationRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _orientationRepository.Delete(orientation);

                return;
            }

            orientation.Set(command.Name, command.Abbreviation);

            await _orientationRepository.Update(orientation);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
