using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record GetPhotoType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetPhotoType, DomainModel>
    {
        private readonly IDomainRepository<PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetPhotoType query)
        {
            return new DomainModel(await _photoTypeRepository.Get(query.Id));
        }
    }
}
