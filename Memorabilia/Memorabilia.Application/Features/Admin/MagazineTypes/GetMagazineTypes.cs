using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public record GetMagazineTypes() : IQuery<MagazineTypesViewModel>
{
    public class Handler : QueryHandler<GetMagazineTypes, MagazineTypesViewModel>
    {
        private readonly IDomainRepository<MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task<MagazineTypesViewModel> Handle(GetMagazineTypes query)
        {
            return new MagazineTypesViewModel(await _magazineTypeRepository.GetAll());
        }
    }
}
