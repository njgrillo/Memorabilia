namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleType(int Id) : IQuery<Entity.JerseyStyleType>
{
    public class Handler : QueryHandler<GetJerseyStyleType, Entity.JerseyStyleType>
    {
        private readonly IDomainRepository<Entity.JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<Entity.JerseyStyleType> Handle(GetJerseyStyleType query)
            => await _jerseyStyleTypeRepository.Get(query.Id);
    }
}
