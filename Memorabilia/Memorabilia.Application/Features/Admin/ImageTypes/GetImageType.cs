namespace Memorabilia.Application.Features.Admin.ImageTypes;

public record GetImageType(int Id) : IQuery<Entity.ImageType>
{
    public class Handler : QueryHandler<GetImageType, Entity.ImageType>
    {
        private readonly IDomainRepository<Entity.ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<Entity.ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<Entity.ImageType> Handle(GetImageType query)
            => await _imageTypeRepository.Get(query.Id);
    }
}
