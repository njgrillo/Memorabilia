namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public record GetHelmetTypes() : IQuery<Entity.HelmetType[]>
{
    public class Handler(IDomainRepository<Entity.HelmetType> helmetTypeRepository) 
        : QueryHandler<GetHelmetTypes, Entity.HelmetType[]>
    {
        protected override async Task<Entity.HelmetType[]> Handle(GetHelmetTypes query)
            => await helmetTypeRepository.GetAll();
    }
}
