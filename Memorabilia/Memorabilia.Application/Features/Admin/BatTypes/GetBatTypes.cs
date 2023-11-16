namespace Memorabilia.Application.Features.Admin.BatTypes;

public record GetBatTypes() : IQuery<Entity.BatType[]>
{
    public class Handler(IDomainRepository<Entity.BatType> batTypeRepository) 
        : QueryHandler<GetBatTypes, Entity.BatType[]>
    {
        protected override async Task<Entity.BatType[]> Handle(GetBatTypes query)
            => await batTypeRepository.GetAll();
    }
}
