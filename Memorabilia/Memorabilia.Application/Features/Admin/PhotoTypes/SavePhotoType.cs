namespace Memorabilia.Application.Features.Admin.PhotoTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SavePhotoType(DomainEditModel PhotoType) : ICommand
{
    public class Handler : CommandHandler<SavePhotoType>
    {
        private readonly IDomainRepository<Entity.PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<Entity.PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task Handle(SavePhotoType request)
        {
            Entity.PhotoType photoType;

            if (request.PhotoType.IsNew)
            {
                photoType = new Entity.PhotoType(request.PhotoType.Name, 
                                                 request.PhotoType.Abbreviation);

                await _photoTypeRepository.Add(photoType);

                return;
            }

            photoType = await _photoTypeRepository.Get(request.PhotoType.Id);

            if (request.PhotoType.IsDeleted)
            {
                await _photoTypeRepository.Delete(photoType);

                return;
            }

            photoType.Set(request.PhotoType.Name, 
                          request.PhotoType.Abbreviation);

            await _photoTypeRepository.Update(photoType);
        }
    }
}
