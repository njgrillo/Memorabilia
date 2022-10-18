using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public record GetImageType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetImageType, DomainViewModel>
    {
        private readonly IDomainRepository<ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetImageType query)
        {
            return new DomainViewModel(await _imageTypeRepository.Get(query.Id));
        }
    }
}
