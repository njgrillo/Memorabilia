namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetInscriptionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetInscriptionType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<Entity.InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetInscriptionType query)
            => await _inscriptionTypeRepository.Get(query.Id);
    }
}
