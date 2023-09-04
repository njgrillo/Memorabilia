namespace Memorabilia.Application.Features.Admin.CerealTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetCerealTypes() : IQuery<Entity.CerealType[]>
{
    public class Handler : QueryHandler<GetCerealTypes, Entity.CerealType[]>
    {
        private readonly IDomainRepository<Entity.CerealType> _CerealTypeRepository;

        public Handler(IDomainRepository<Entity.CerealType> CerealTypeRepository)
        {
            _CerealTypeRepository = CerealTypeRepository;
        }

        protected override async Task<Entity.CerealType[]> Handle(GetCerealTypes query)
            => await _CerealTypeRepository.GetAll();
    }
}
