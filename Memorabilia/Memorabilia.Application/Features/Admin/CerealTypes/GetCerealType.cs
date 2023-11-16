namespace Memorabilia.Application.Features.Admin.CerealTypes;

public record GetCerealType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.CerealType> CerealTypeRepository) 
        : QueryHandler<GetCerealType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetCerealType query)
            => await CerealTypeRepository.Get(query.Id);
    }
}
