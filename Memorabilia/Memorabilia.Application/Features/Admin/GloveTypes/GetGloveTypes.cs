namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record GetGloveTypes() : IQuery<Entity.GloveType[]>
{
    public class Handler(IDomainRepository<Entity.GloveType> gloveTypeRepository) 
        : QueryHandler<GetGloveTypes, Entity.GloveType[]>
    {
        protected override async Task<Entity.GloveType[]> Handle(GetGloveTypes query)
            => await gloveTypeRepository.GetAll();
    }
}
