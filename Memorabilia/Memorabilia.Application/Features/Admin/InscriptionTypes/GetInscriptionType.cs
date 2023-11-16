namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record GetInscriptionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.InscriptionType> inscriptionTypeRepository) 
        : QueryHandler<GetInscriptionType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetInscriptionType query)
            => await inscriptionTypeRepository.Get(query.Id);
    }
}
