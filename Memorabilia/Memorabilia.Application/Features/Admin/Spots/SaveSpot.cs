using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Spots
{
    public class SaveSpot
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ISpotRepository _spotRepository;

            public Handler(ISpotRepository spotRepository)
            {
                _spotRepository = spotRepository;
            }

            protected override async Task Handle(Command command)
            {
                Spot spot;

                if (command.IsNew)
                {
                    spot = new Spot(command.Name, command.Abbreviation);
                    await _spotRepository.Add(spot).ConfigureAwait(false);

                    return;
                }

                spot = await _spotRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _spotRepository.Delete(spot).ConfigureAwait(false);

                    return;
                }

                spot.Set(command.Name, command.Abbreviation);

                await _spotRepository.Update(spot).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
