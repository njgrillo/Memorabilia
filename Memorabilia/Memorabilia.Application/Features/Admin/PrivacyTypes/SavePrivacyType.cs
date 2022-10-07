using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public class SavePrivacyType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            PrivacyType privacyType;

            if (command.IsNew)
            {
                privacyType = new PrivacyType(command.Name, command.Abbreviation);

                await _privacyTypeRepository.Add(privacyType);

                return;
            }

            privacyType = await _privacyTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _privacyTypeRepository.Delete(privacyType);

                return;
            }

            privacyType.Set(command.Name, command.Abbreviation);

            await _privacyTypeRepository.Update(privacyType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
