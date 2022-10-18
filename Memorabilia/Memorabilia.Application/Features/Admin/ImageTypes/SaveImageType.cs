using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public record SaveImageType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveImageType>
    {
        private readonly IDomainRepository<ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task Handle(SaveImageType request)
        {
            ImageType imageType;

            if (request.ViewModel.IsNew)
            {
                imageType = new ImageType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _imageTypeRepository.Add(imageType);

                return;
            }

            imageType = await _imageTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _imageTypeRepository.Delete(imageType);

                return;
            }

            imageType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _imageTypeRepository.Update(imageType);
        }
    }
}
