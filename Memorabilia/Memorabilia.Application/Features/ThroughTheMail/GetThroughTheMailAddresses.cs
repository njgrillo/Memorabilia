namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetThroughTheMailAddresses(int PersonId) : IQuery<Entity.Address[]>
{
    public class Handler : QueryHandler<GetThroughTheMailAddresses, Entity.Address[]>
    {
        private readonly IThroughTheMailRepository _throughTheMailRepository;

        public Handler(IThroughTheMailRepository throughTheMailRepository)
        {
            _throughTheMailRepository = throughTheMailRepository;
        }

        protected override async Task<Entity.Address[]> Handle(GetThroughTheMailAddresses query)
            => (await _throughTheMailRepository.GetAddresses(query.PersonId))
                   .ToArray();
    }
}
