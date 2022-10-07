using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public class SaveFranchiseHallOfFameType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            FranchiseHallOfFameType franchiseHallOfFameType;

            if (command.IsNew)
            {
                franchiseHallOfFameType = new FranchiseHallOfFameType(command.Name, command.Abbreviation);
                await _franchiseHallOfFameTypeRepository.Add(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType = await _franchiseHallOfFameTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _franchiseHallOfFameTypeRepository.Delete(franchiseHallOfFameType);

                return;
            }

            franchiseHallOfFameType.Set(command.Name, command.Abbreviation);

            await _franchiseHallOfFameTypeRepository.Update(franchiseHallOfFameType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
