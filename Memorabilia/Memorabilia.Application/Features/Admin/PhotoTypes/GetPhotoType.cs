namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record GetPhotoType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.PhotoType> photoTypeRepository) 
        : QueryHandler<GetPhotoType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetPhotoType query)
            => await photoTypeRepository.Get(query.Id);
    }
}
