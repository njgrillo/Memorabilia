namespace Memorabilia.Application.Features.Admin.Sizes;

public record GetSize(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.Size> sizeRepository) 
        : QueryHandler<GetSize, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetSize query)
            => await sizeRepository.Get(query.Id);
    }
}
