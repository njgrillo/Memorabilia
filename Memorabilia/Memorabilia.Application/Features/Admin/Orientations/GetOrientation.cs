namespace Memorabilia.Application.Features.Admin.Orientations;

public record GetOrientation(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.Orientation> orientationRepository) 
        : QueryHandler<GetOrientation, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetOrientation query)
            => await orientationRepository.Get(query.Id);
    }
}
