using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public class SavePhotoType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            PhotoType photoType;

            if (command.IsNew)
            {
                photoType = new PhotoType(command.Name, command.Abbreviation);

                await _photoTypeRepository.Add(photoType);

                return;
            }

            photoType = await _photoTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _photoTypeRepository.Delete(photoType);

                return;
            }

            photoType.Set(command.Name, command.Abbreviation);

            await _photoTypeRepository.Update(photoType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
