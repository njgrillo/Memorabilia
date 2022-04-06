using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PhotoTypes
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
                return new PhotoTypesViewModel(await _photoTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PhotoTypesViewModel> { }
    }
}
