using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public record GetImageTypes() : IQuery<ImageTypesViewModel>
{
    public class Handler : QueryHandler<GetImageTypes, ImageTypesViewModel>
    {
        private readonly IDomainRepository<ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<ImageTypesViewModel> Handle(GetImageTypes query)
        {
            return new ImageTypesViewModel(await _imageTypeRepository.GetAll());
        }
    }
}
