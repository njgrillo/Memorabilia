using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record GetMagazineType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetMagazineType, DomainViewModel>
    {
        private readonly IDomainRepository<MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetMagazineType query)
        {
            return new DomainViewModel(await _magazineTypeRepository.Get(query.Id));
        }
    }
}
