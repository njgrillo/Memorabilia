namespace Memorabilia.Application.Features.Admin.MagazineTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetMagazineTypes() : IQuery<Entity.MagazineType[]>
{
    public class Handler : QueryHandler<GetMagazineTypes, Entity.MagazineType[]>
    {
        private readonly IDomainRepository<Entity.MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<Entity.MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task<Entity.MagazineType[]> Handle(GetMagazineTypes query)
            => await _magazineTypeRepository.GetAll();
    }
}
