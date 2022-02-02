using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ImageType
{
    public class GetImageType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IImageTypeRepository _imageTypeRepository;

            public Handler(IImageTypeRepository imageTypeRepository)
            {
                _imageTypeRepository = imageTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var imageType = await _imageTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(imageType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
