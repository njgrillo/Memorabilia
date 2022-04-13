using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes
{
    public class SaveFranchiseHallOfFameType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IFranchiseHallOfFameTypeRepository _franchiseHallOfFameTypeRepository;

            public Handler(IFranchiseHallOfFameTypeRepository franchiseHallOfFameTypeRepository)
            {
                _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                FranchiseHallOfFameType franchiseHallOfFameType;

                if (command.IsNew)
                {
                    franchiseHallOfFameType = new FranchiseHallOfFameType(command.Name, command.Abbreviation);
                    await _franchiseHallOfFameTypeRepository.Add(franchiseHallOfFameType).ConfigureAwait(false);

                    return;
                }

                franchiseHallOfFameType = await _franchiseHallOfFameTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _franchiseHallOfFameTypeRepository.Delete(franchiseHallOfFameType).ConfigureAwait(false);

                    return;
                }

                franchiseHallOfFameType.Set(command.Name, command.Abbreviation);

                await _franchiseHallOfFameTypeRepository.Update(franchiseHallOfFameType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
