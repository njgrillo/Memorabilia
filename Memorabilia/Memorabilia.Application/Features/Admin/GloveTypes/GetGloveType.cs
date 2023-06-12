namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record GetGloveType(int Id) : IQuery<Entity.GloveType>
{
    public class Handler : QueryHandler<GetGloveType, Entity.GloveType>
    {
        private readonly IDomainRepository<Entity.GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<Entity.GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<Entity.GloveType> Handle(GetGloveType query)
            => await _gloveTypeRepository.Get(query.Id);
    }
}
