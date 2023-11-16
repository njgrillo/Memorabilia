namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetThroughTheMailAddresses(int PersonId) : IQuery<Entity.Address[]>
{
    public class Handler(IThroughTheMailRepository throughTheMailRepository) 
        : QueryHandler<GetThroughTheMailAddresses, Entity.Address[]>
    {
        protected override async Task<Entity.Address[]> Handle(GetThroughTheMailAddresses query)
            => (await throughTheMailRepository.GetAddresses(query.PersonId))
                   .ToArray();
    }
}
