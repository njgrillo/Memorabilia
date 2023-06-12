namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record GetInscriptionType(int Id) : IQuery<Entity.InscriptionType>
{
    public class Handler : QueryHandler<GetInscriptionType, Entity.InscriptionType>
    {
        private readonly IDomainRepository<Entity.InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<Entity.InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<Entity.InscriptionType> Handle(GetInscriptionType query)
            => await _inscriptionTypeRepository.Get(query.Id);
    }
}
