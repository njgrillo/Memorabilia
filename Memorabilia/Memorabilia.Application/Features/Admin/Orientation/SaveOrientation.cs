using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Orientation
{
    public class SaveOrientation
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IOrientationRepository _orientationRepository;

            public Handler(IOrientationRepository orientationRepository)
            {
                _orientationRepository = orientationRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Orientation orientation;

                if (command.IsNew)
                {
                    orientation = new Domain.Entities.Orientation(command.Name, command.Abbreviation);
                    await _orientationRepository.Add(orientation).ConfigureAwait(false);

                    return;
                }

                orientation = await _orientationRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _orientationRepository.Delete(orientation).ConfigureAwait(false);

                    return;
                }

                orientation.Set(command.Name, command.Abbreviation);

                await _orientationRepository.Update(orientation).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
