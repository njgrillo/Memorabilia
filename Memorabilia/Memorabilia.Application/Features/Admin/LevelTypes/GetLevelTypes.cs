namespace Memorabilia.Application.Features.Admin.LevelTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetLevelTypes() : IQuery<Entity.LevelType[]>
{
    public class Handler : QueryHandler<GetLevelTypes, Entity.LevelType[]>
    {
        private readonly IDomainRepository<Entity.LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<Entity.LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task<Entity.LevelType[]> Handle(GetLevelTypes query)
            => await _levelTypeRepository.GetAll();
    }
}
