using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PhotoType
{
    public class SavePhotoType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IPhotoTypeRepository _photoTypeRepository;

            public Handler(IPhotoTypeRepository photoTypeRepository)
            {
                _photoTypeRepository = photoTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.PhotoType photoType;

                if (command.IsNew)
                {
                    photoType = new Domain.Entities.PhotoType(command.Name, command.Abbreviation);
                    await _photoTypeRepository.Add(photoType).ConfigureAwait(false);

                    return;
                }

                photoType = await _photoTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _photoTypeRepository.Delete(photoType).ConfigureAwait(false);

                    return;
                }

                photoType.Set(command.Name, command.Abbreviation);

                await _photoTypeRepository.Update(photoType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
