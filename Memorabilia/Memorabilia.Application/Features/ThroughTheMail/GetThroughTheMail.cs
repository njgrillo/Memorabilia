namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetThroughTheMail(int Id) : IQuery<Entity.ThroughTheMail>
{
    public class Handler : QueryHandler<GetThroughTheMail, Entity.ThroughTheMail>
    {
        private readonly IThroughTheMailRepository _throughTheMailRepository;

        public Handler(IThroughTheMailRepository throughTheMailRepository)
        {
            _throughTheMailRepository = throughTheMailRepository;
        }

        protected override async Task<Entity.ThroughTheMail> Handle(GetThroughTheMail query)
            => await _throughTheMailRepository.Get(query.Id);
    }
}
