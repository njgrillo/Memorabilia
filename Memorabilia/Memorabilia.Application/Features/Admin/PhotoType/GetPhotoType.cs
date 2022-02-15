using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PhotoType
{
    public class GetPhotoType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IPhotoTypeRepository _photoTypeRepository;

            public Handler(IPhotoTypeRepository photoTypeRepository)
            {
                _photoTypeRepository = photoTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var photoType = await _photoTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(photoType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
