using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public class GetPhotoTypes
{
    public class Handler : QueryHandler<Query, PhotoTypesViewModel>
    {
        private readonly IDomainRepository<PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<PhotoTypesViewModel> Handle(Query query)
        {
            return new PhotoTypesViewModel(await _photoTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<PhotoTypesViewModel> { }
}
