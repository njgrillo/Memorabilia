namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record GetInscriptionTypes() : IQuery<Entity.InscriptionType[]>
{
    public class Handler(IDomainRepository<Entity.InscriptionType> inscriptionTypeRepository) 
        : QueryHandler<GetInscriptionTypes, Entity.InscriptionType[]>
    {
        protected override async Task<Entity.InscriptionType[]> Handle(GetInscriptionTypes query)
            => await inscriptionTypeRepository.GetAll();
    }
}
