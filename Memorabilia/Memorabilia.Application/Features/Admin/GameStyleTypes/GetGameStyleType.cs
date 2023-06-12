namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public record GetGameStyleType(int Id) : IQuery<Entity.GameStyleType>
{
    public class Handler : QueryHandler<GetGameStyleType, Entity.GameStyleType>
    {
        private readonly IDomainRepository<Entity.GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<Entity.GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<Entity.GameStyleType> Handle(GetGameStyleType query)
            => await _gameStyleTypeRepository.Get(query.Id);
    }
}
