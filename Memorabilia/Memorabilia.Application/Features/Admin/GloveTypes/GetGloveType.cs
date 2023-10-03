namespace Memorabilia.Application.Features.Admin.GloveTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetGloveType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetGloveType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<Entity.GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetGloveType query)
            => await _gloveTypeRepository.Get(query.Id);
    }
}
