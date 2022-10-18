using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public record SaveSpot(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveSpot>
    {
        private readonly IDomainRepository<Spot> _spotRepository;

        public Handler(IDomainRepository<Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task Handle(SaveSpot request)
        {
            Spot spot;

            if (request.ViewModel.IsNew)
            {
                spot = new Spot(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _spotRepository.Add(spot);

                return;
            }

            spot = await _spotRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _spotRepository.Delete(spot);

                return;
            }

            spot.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _spotRepository.Update(spot);
        }
    }
}
