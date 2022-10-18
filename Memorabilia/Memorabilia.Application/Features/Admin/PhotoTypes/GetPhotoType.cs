using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record GetPhotoType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetPhotoType, DomainViewModel>
    {
        private readonly IDomainRepository<PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetPhotoType query)
        {
            return new DomainViewModel(await _photoTypeRepository.Get(query.Id));
        }
    }
}
