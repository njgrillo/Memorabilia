using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public class GetImageType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _imageTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
