namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record GetBammerType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.BammerType> bammerTypeRepository) 
        : QueryHandler<GetBammerType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetBammerType query)
            => await bammerTypeRepository.Get(query.Id);
    }
}
