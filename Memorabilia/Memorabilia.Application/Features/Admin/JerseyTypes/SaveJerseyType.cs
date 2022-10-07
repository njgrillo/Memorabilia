using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public class SaveJerseyType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            JerseyType jerseyType;

            if (command.IsNew)
            {
                jerseyType = new JerseyType(command.Name, command.Abbreviation);

                await _jerseyTypeRepository.Add(jerseyType);

                return;
            }

            jerseyType = await _jerseyTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _jerseyTypeRepository.Delete(jerseyType);

                return;
            }

            jerseyType.Set(command.Name, command.Abbreviation);

            await _jerseyTypeRepository.Update(jerseyType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
