namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetJerseyStyleType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetJerseyStyleType query)
            => await _jerseyStyleTypeRepository.Get(query.Id);
    }
}
