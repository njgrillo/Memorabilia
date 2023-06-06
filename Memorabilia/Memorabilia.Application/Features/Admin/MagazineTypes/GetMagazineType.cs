using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record GetMagazineType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetMagazineType, DomainModel>
    {
        private readonly IDomainRepository<MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetMagazineType query)
        {
            return new DomainModel(await _magazineTypeRepository.Get(query.Id));
        }
    }
}
