using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ImageTypes
{
    public class SaveImageType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IImageTypeRepository _imageTypeRepository;

            public Handler(IImageTypeRepository imageTypeRepository)
            {
                _imageTypeRepository = imageTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                ImageType imageType;

                if (command.IsNew)
                {
                    imageType = new ImageType(command.Name, command.Abbreviation);
                    await _imageTypeRepository.Add(imageType).ConfigureAwait(false);

                    return;
                }

                imageType = await _imageTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _imageTypeRepository.Delete(imageType).ConfigureAwait(false);

                    return;
                }

                imageType.Set(command.Name, command.Abbreviation);

                await _imageTypeRepository.Update(imageType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
