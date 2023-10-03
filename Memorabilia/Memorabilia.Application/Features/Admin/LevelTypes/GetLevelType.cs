namespace Memorabilia.Application.Features.Admin.LevelTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetLevelType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetLevelType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<Entity.LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetLevelType query)
            => await _levelTypeRepository.Get(query.Id);
    }
}
