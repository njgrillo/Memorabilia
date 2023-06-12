namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public record GetJerseyType(int Id) : IQuery<Entity.JerseyType>
{
    public class Handler : QueryHandler<GetJerseyType, Entity.JerseyType>
    {
        private readonly IDomainRepository<Entity.JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<Entity.JerseyType> Handle(GetJerseyType query)
            => await _jerseyTypeRepository.Get(query.Id);
    }
}
