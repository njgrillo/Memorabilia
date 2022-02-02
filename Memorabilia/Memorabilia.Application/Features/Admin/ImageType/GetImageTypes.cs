using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ImageType
{
    public class GetImageTypes
    {
        public class Handler : QueryHandler<Query, ImageTypesViewModel>
        {
            private readonly IImageTypeRepository _imageTypeRepository;

            public Handler(IImageTypeRepository imageTypeRepository)
            {
                _imageTypeRepository = imageTypeRepository;
            }

            protected override async Task<ImageTypesViewModel> Handle(Query query)
            {
                var imageTypes = await _imageTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new ImageTypesViewModel(imageTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<ImageTypesViewModel>
        {
        }
    }
}
