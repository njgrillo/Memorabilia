namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record GetGloveTypes() : IQuery<Entity.GloveType[]>
{
    public class Handler : QueryHandler<GetGloveTypes, Entity.GloveType[]>
    {
        private readonly IDomainRepository<Entity.GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<Entity.GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<Entity.GloveType[]> Handle(GetGloveTypes query)
            => await _gloveTypeRepository.GetAll();
    }
}
