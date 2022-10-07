using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public class GetMagazineTypes
{
    public class Handler : QueryHandler<Query, MagazineTypesViewModel>
    {
        private readonly IDomainRepository<MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task<MagazineTypesViewModel> Handle(Query query)
        {
            return new MagazineTypesViewModel(await _magazineTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<MagazineTypesViewModel> { }
}
