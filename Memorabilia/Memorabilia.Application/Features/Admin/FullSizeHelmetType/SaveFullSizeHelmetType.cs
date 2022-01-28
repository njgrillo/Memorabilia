using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FullSizeHelmetType
{
    public class SaveFullSizeHelmetType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IFullSizeHelmetTypeRepository _fullSizeHelmetTypeRepository;

            public Handler(IFullSizeHelmetTypeRepository fullSizeHelmetTypeRepository)
            {
                _fullSizeHelmetTypeRepository = fullSizeHelmetTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.FullSizeHelmetType fullSizeHelmetType;

                if (command.IsNew)
                {
                    fullSizeHelmetType = new Domain.Entities.FullSizeHelmetType(command.Name, command.Abbreviation);
                    await _fullSizeHelmetTypeRepository.Add(fullSizeHelmetType).ConfigureAwait(false);

                    return;
                }

                fullSizeHelmetType = await _fullSizeHelmetTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _fullSizeHelmetTypeRepository.Delete(fullSizeHelmetType).ConfigureAwait(false);

                    return;
                }

                fullSizeHelmetType.Set(command.Name, command.Abbreviation);

                await _fullSizeHelmetTypeRepository.Update(fullSizeHelmetType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel)
            {
            }
        }
    }
}
