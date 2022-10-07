using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public class SaveSpot
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Spot> _spotRepository;

        public Handler(IDomainRepository<Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task Handle(Command command)
        {
            Spot spot;

            if (command.IsNew)
            {
                spot = new Spot(command.Name, command.Abbreviation);

                await _spotRepository.Add(spot);

                return;
            }

            spot = await _spotRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _spotRepository.Delete(spot);

                return;
            }

            spot.Set(command.Name, command.Abbreviation);

            await _spotRepository.Update(spot);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
