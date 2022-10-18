using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record GetPhotoTypes() : IQuery<PhotoTypesViewModel>
{
    public class Handler : QueryHandler<GetPhotoTypes, PhotoTypesViewModel>
    {
        private readonly IDomainRepository<PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<PhotoTypesViewModel> Handle(GetPhotoTypes query)
        {
            return new PhotoTypesViewModel(await _photoTypeRepository.GetAll());
        }
    }
}
