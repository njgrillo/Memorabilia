namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetGameStyleTypes() : IQuery<Entity.GameStyleType[]>
{
    public class Handler : QueryHandler<GetGameStyleTypes, Entity.GameStyleType[]>
    {
        private readonly IDomainRepository<Entity.GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<Entity.GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<Entity.GameStyleType[]> Handle(GetGameStyleTypes query)
            => await _gameStyleTypeRepository.GetAll();
    }
}
