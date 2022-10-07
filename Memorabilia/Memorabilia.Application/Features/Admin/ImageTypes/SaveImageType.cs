using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageTypes;

public class SaveImageType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<ImageType> _imageTypeRepository;

        public Handler(IDomainRepository<ImageType> imageTypeRepository)
        {
            _imageTypeRepository = imageTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            ImageType imageType;

            if (command.IsNew)
            {
                imageType = new ImageType(command.Name, command.Abbreviation);

                await _imageTypeRepository.Add(imageType);

                return;
            }

            imageType = await _imageTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _imageTypeRepository.Delete(imageType);

                return;
            }

            imageType.Set(command.Name, command.Abbreviation);

            await _imageTypeRepository.Update(imageType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
