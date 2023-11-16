namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record GetMagazineType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.MagazineType> magazineTypeRepository) 
        : QueryHandler<GetMagazineType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetMagazineType query)
            => await magazineTypeRepository.Get(query.Id);
    }
}
