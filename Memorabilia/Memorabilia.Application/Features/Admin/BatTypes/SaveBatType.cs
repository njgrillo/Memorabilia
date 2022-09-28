using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes
{
    public class SaveBatType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IBatTypeRepository _batTypeRepository;

            public Handler(IBatTypeRepository batTypeRepository)
            {
                _batTypeRepository = batTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                BatType batType;

                if (command.IsNew)
                {
                    batType = new BatType(command.Name, command.Abbreviation);
                    await _batTypeRepository.Add(batType).ConfigureAwait(false);

                    return;
                }

                batType = await _batTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _batTypeRepository.Delete(batType).ConfigureAwait(false);

                    return;
                }

                batType.Set(command.Name, command.Abbreviation);

                await _batTypeRepository.Update(batType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
