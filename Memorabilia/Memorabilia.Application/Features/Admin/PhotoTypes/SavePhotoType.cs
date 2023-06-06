using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record SavePhotoType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SavePhotoType>
    {
        private readonly IDomainRepository<PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task Handle(SavePhotoType request)
        {
            PhotoType photoType;

            if (request.ViewModel.IsNew)
            {
                photoType = new PhotoType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _photoTypeRepository.Add(photoType);

                return;
            }

            photoType = await _photoTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _photoTypeRepository.Delete(photoType);

                return;
            }

            photoType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _photoTypeRepository.Update(photoType);
        }
    }
}
