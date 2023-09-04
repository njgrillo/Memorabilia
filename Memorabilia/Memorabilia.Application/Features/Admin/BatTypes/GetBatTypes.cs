namespace Memorabilia.Application.Features.Admin.BatTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetBatTypes() : IQuery<Entity.BatType[]>
{
    public class Handler : QueryHandler<GetBatTypes, Entity.BatType[]>
    {
        private readonly IDomainRepository<Entity.BatType> _batTypeRepository;

        public Handler(IDomainRepository<Entity.BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<Entity.BatType[]> Handle(GetBatTypes query)
            => await _batTypeRepository.GetAll();
    }
}
