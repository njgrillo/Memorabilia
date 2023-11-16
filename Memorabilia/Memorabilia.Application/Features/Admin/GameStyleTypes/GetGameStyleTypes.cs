namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public record GetGameStyleTypes() : IQuery<Entity.GameStyleType[]>
{
    public class Handler(IDomainRepository<Entity.GameStyleType> gameStyleTypeRepository) 
        : QueryHandler<GetGameStyleTypes, Entity.GameStyleType[]>
    {
        protected override async Task<Entity.GameStyleType[]> Handle(GetGameStyleTypes query)
            => await gameStyleTypeRepository.GetAll();
    }
}
