namespace Memorabilia.Application.Features.Admin.ImageTypes;

public record GetImageType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.ImageType> imageTypeRepository) 
        : QueryHandler<GetImageType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetImageType query)
            => await imageTypeRepository.Get(query.Id);
    }
}
