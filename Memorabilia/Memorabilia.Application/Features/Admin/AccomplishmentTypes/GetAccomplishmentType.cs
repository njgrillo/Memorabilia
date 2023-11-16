namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository) 
        : QueryHandler<GetAccomplishmentType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetAccomplishmentType query)
            => await accomplishmentTypeRepository.Get(query.Id);
    }
}
