using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.MagazineTypes;

public class GetMagazineType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<MagazineType> _magazineTypeRepository;

        public Handler(IDomainRepository<MagazineType> magazineTypeRepository)
        {
            _magazineTypeRepository = magazineTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _magazineTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
