namespace Memorabilia.Application.Features.Admin.ImageTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveImageType(DomainEditModel ImageType) : ICommand
{
    public class Handler : CommandHandler<SaveImageType>
    {
        private readonly IDomainRepository<Entity.ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<Entity.ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task Handle(SaveImageType request)
        {
            Entity.ImageType imageType;

            if (request.ImageType.IsNew)
            {
                imageType = new Entity.ImageType(request.ImageType.Name, 
                                                 request.ImageType.Abbreviation);

                await _imageTypeRepository.Add(imageType);

                return;
            }

            imageType = await _imageTypeRepository.Get(request.ImageType.Id);

            if (request.ImageType.IsDeleted)
            {
                await _imageTypeRepository.Delete(imageType);

                return;
            }

            imageType.Set(request.ImageType.Name, 
                          request.ImageType.Abbreviation);

            await _imageTypeRepository.Update(imageType);
        }
    }
}
