namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record GetMagazineType(int Id) : IQuery<Entity.MagazineType>
{
    public class Handler : QueryHandler<GetMagazineType, Entity.MagazineType>
    {
        private readonly IDomainRepository<Entity.MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<Entity.MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task<Entity.MagazineType> Handle(GetMagazineType query)
            => await _magazineTypeRepository.Get(query.Id);
    }
}
