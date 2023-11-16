namespace Memorabilia.Application.Features.Admin.ImageTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveImageType(DomainEditModel ImageType) : ICommand
{
    public class Handler(IDomainRepository<Entity.ImageType> imageTypeRepository) 
        : CommandHandler<SaveImageType>
    {
        protected override async Task Handle(SaveImageType request)
        {
            Entity.ImageType imageType;

            if (request.ImageType.IsNew)
            {
                imageType = new Entity.ImageType(request.ImageType.Name, 
                                                 request.ImageType.Abbreviation);

                await imageTypeRepository.Add(imageType);

                return;
            }

            imageType = await imageTypeRepository.Get(request.ImageType.Id);

            if (request.ImageType.IsDeleted)
            {
                await imageTypeRepository.Delete(imageType);

                return;
            }

            imageType.Set(request.ImageType.Name, 
                          request.ImageType.Abbreviation);

            await imageTypeRepository.Update(imageType);
        }
    }
}
