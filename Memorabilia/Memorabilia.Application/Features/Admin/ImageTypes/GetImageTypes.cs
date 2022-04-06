using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ImageTypes
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
                return new ImageTypesViewModel(await _imageTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ImageTypesViewModel> { }
    }
}
