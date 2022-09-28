using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes
{
    public class SaveInternationalHallOfFameType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IInternationalHallOfFameTypeRepository _internationalHallOfFameTypeRepository;

            public Handler(IInternationalHallOfFameTypeRepository internationalHallOfFameTypeRepository)
            {
                _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                InternationalHallOfFameType internationalHallOfFameType;

                if (command.IsNew)
                {
                    internationalHallOfFameType = new InternationalHallOfFameType(command.Name, command.Abbreviation);
                    await _internationalHallOfFameTypeRepository.Add(internationalHallOfFameType).ConfigureAwait(false);

                    return;
                }

                internationalHallOfFameType = await _internationalHallOfFameTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _internationalHallOfFameTypeRepository.Delete(internationalHallOfFameType).ConfigureAwait(false);

                    return;
                }

                internationalHallOfFameType.Set(command.Name, command.Abbreviation);

                await _internationalHallOfFameTypeRepository.Update(internationalHallOfFameType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
