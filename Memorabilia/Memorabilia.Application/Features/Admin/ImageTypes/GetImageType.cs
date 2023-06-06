using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public record GetImageType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetImageType, DomainModel>
    {
        private readonly IDomainRepository<ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetImageType query)
        {
            return new DomainModel(await _imageTypeRepository.Get(query.Id));
        }
    }
}
