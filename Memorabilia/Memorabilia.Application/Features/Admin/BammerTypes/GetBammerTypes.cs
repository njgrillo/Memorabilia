namespace Memorabilia.Application.Features.Admin.BammerTypes;

public record GetBammerTypes() : IQuery<Entity.BammerType[]>
{
    public class Handler(IDomainRepository<Entity.BammerType> bammerTypeRepository) 
        : QueryHandler<GetBammerTypes, Entity.BammerType[]>
    {
        protected override async Task<Entity.BammerType[]> Handle(GetBammerTypes query)
            => await bammerTypeRepository.GetAll();
    }
}
