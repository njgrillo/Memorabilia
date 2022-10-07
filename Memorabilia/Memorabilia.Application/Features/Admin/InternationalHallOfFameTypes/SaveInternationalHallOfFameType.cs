using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public class SaveInternationalHallOfFameType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            InternationalHallOfFameType internationalHallOfFameType;

            if (command.IsNew)
            {
                internationalHallOfFameType = new InternationalHallOfFameType(command.Name, command.Abbreviation);

                await _internationalHallOfFameTypeRepository.Add(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType = await _internationalHallOfFameTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _internationalHallOfFameTypeRepository.Delete(internationalHallOfFameType);

                return;
            }

            internationalHallOfFameType.Set(command.Name, command.Abbreviation);

            await _internationalHallOfFameTypeRepository.Update(internationalHallOfFameType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
