namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record GetBaseballTypes() : IQuery<Entity.BaseballType[]>
{
    public class Handler(IDomainRepository<Entity.BaseballType> baseballTypeRepository) 
        : QueryHandler<GetBaseballTypes, Entity.BaseballType[]>
    {
        protected override async Task<Entity.BaseballType[]> Handle(GetBaseballTypes query)
            => await baseballTypeRepository.GetAll();
    }
}
