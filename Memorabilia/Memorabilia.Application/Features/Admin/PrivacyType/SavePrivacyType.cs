using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PrivacyType
{
    public class SavePrivacyType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IPrivacyTypeRepository _privacyTypeRepository;

            public Handler(IPrivacyTypeRepository privacyTypeRepository)
            {
                _privacyTypeRepository = privacyTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.PrivacyType privacyType;

                if (command.IsNew)
                {
                    privacyType = new Domain.Entities.PrivacyType(command.Name, command.Abbreviation);
                    await _privacyTypeRepository.Add(privacyType).ConfigureAwait(false);

                    return;
                }

                privacyType = await _privacyTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _privacyTypeRepository.Delete(privacyType).ConfigureAwait(false);

                    return;
                }

                privacyType.Set(command.Name, command.Abbreviation);

                await _privacyTypeRepository.Update(privacyType).ConfigureAwait(false);
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
