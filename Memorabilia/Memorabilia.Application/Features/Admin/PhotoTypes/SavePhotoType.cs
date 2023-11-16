namespace Memorabilia.Application.Features.Admin.PhotoTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePhotoType(DomainEditModel PhotoType) : ICommand
{
    public class Handler(IDomainRepository<Entity.PhotoType> photoTypeRepository) 
        : CommandHandler<SavePhotoType>
    {
        protected override async Task Handle(SavePhotoType request)
        {
            Entity.PhotoType photoType;

            if (request.PhotoType.IsNew)
            {
                photoType = new Entity.PhotoType(request.PhotoType.Name, 
                                                 request.PhotoType.Abbreviation);

                await photoTypeRepository.Add(photoType);

                return;
            }

            photoType = await photoTypeRepository.Get(request.PhotoType.Id);

            if (request.PhotoType.IsDeleted)
            {
                await photoTypeRepository.Delete(photoType);

                return;
            }

            photoType.Set(request.PhotoType.Name, 
                          request.PhotoType.Abbreviation);

            await photoTypeRepository.Update(photoType);
        }
    }
}
