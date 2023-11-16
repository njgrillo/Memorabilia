namespace Memorabilia.Application.Features.Admin.Spots;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveSpot(DomainEditModel Spot) : ICommand
{
    public class Handler(IDomainRepository<Entity.Spot> spotRepository) 
        : CommandHandler<SaveSpot>
    {
        protected override async Task Handle(SaveSpot request)
        {
            Entity.Spot spot;

            if (request.Spot.IsNew)
            {
                spot = new Entity.Spot(request.Spot.Name, 
                                       request.Spot.Abbreviation);

                await spotRepository.Add(spot);

                return;
            }

            spot = await spotRepository.Get(request.Spot.Id);

            if (request.Spot.IsDeleted)
            {
                await spotRepository.Delete(spot);

                return;
            }

            spot.Set(request.Spot.Name, 
                     request.Spot.Abbreviation);

            await spotRepository.Update(spot);
        }
    }
}
