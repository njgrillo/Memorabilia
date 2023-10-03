namespace Memorabilia.Application.Features.Admin.ImageTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetImageType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetImageType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<Entity.ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetImageType query)
            => await _imageTypeRepository.Get(query.Id);
    }
}
