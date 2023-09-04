namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetInscriptionTypes() : IQuery<Entity.InscriptionType[]>
{
    public class Handler : QueryHandler<GetInscriptionTypes, Entity.InscriptionType[]>
    {
        private readonly IDomainRepository<Entity.InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<Entity.InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<Entity.InscriptionType[]> Handle(GetInscriptionTypes query)
            => await _inscriptionTypeRepository.GetAll();
    }
}
