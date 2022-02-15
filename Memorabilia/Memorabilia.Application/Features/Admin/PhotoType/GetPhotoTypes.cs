using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PhotoType
{
    public class GetPhotoTypes
    {
        public class Handler : QueryHandler<Query, PhotoTypesViewModel>
        {
            private readonly IPhotoTypeRepository _photoTypeRepository;

            public Handler(IPhotoTypeRepository photoTypeRepository)
            {
                _photoTypeRepository = photoTypeRepository;
            }

            protected override async Task<PhotoTypesViewModel> Handle(Query query)
            {
                var photoTypes = await _photoTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new PhotoTypesViewModel(photoTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<PhotoTypesViewModel> { }
    }
}
