using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Orientations
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
                Orientation orientation;

                if (command.IsNew)
                {
                    orientation = new Orientation(command.Name, command.Abbreviation);
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
