namespace Memorabilia.Application.Features.Admin.Spots;

public record SaveSpot(DomainEditModel Spot) : ICommand
{
    public class Handler : CommandHandler<SaveSpot>
    {
        private readonly IDomainRepository<Entity.Spot> _spotRepository;

        public Handler(IDomainRepository<Entity.Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task Handle(SaveSpot request)
        {
            Entity.Spot spot;

            if (request.Spot.IsNew)
            {
                spot = new Entity.Spot(request.Spot.Name, 
                                       request.Spot.Abbreviation);

                await _spotRepository.Add(spot);

                return;
            }

            spot = await _spotRepository.Get(request.Spot.Id);

            if (request.Spot.IsDeleted)
            {
                await _spotRepository.Delete(spot);

                return;
            }

            spot.Set(request.Spot.Name, 
                     request.Spot.Abbreviation);

            await _spotRepository.Update(spot);
        }
    }
}
