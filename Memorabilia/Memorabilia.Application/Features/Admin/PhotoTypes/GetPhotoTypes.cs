namespace Memorabilia.Application.Features.Admin.PhotoTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetPhotoTypes() : IQuery<Entity.PhotoType[]>
{
    public class Handler : QueryHandler<GetPhotoTypes, Entity.PhotoType[]>
    {
        private readonly IDomainRepository<Entity.PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<Entity.PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<Entity.PhotoType[]> Handle(GetPhotoTypes query)
            => await _photoTypeRepository.GetAll();
    }
}
