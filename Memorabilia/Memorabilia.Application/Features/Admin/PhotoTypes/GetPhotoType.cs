using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public class GetPhotoType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _photoTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
