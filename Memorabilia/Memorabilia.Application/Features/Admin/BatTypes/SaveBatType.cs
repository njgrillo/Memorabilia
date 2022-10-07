using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public class SaveBatType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<BatType> _batTypeRepository;

        public Handler(IDomainRepository<BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            BatType batType;

            if (command.IsNew)
            {
                batType = new BatType(command.Name, command.Abbreviation);

                await _batTypeRepository.Add(batType);

                return;
            }

            batType = await _batTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _batTypeRepository.Delete(batType);

                return;
            }

            batType.Set(command.Name, command.Abbreviation);

            await _batTypeRepository.Update(batType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
