using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public class GetImageTypes
{
    public class Handler : QueryHandler<Query, ImageTypesViewModel>
    {
        private readonly IDomainRepository<ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<ImageTypesViewModel> Handle(Query query)
        {
            return new ImageTypesViewModel(await _imageTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<ImageTypesViewModel> { }
}
