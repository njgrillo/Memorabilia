namespace Memorabilia.Application.Features.Admin.ImageTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetImageTypes() : IQuery<Entity.ImageType[]>
{
    public class Handler : QueryHandler<GetImageTypes, Entity.ImageType[]>
    {
        private readonly IDomainRepository<Entity.ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<Entity.ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<Entity.ImageType[]> Handle(GetImageTypes query)
            => await _imageTypeRepository.GetAll();
    }
}
