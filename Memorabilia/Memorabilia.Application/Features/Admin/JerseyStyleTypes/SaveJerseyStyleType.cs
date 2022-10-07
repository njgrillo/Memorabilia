using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public class SaveJerseyStyleType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            JerseyStyleType jerseyStyleType;

            if (command.IsNew)
            {
                jerseyStyleType = new JerseyStyleType(command.Name, command.Abbreviation);

                await _jerseyStyleTypeRepository.Add(jerseyStyleType);

                return;
            }

            jerseyStyleType = await _jerseyStyleTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _jerseyStyleTypeRepository.Delete(jerseyStyleType);

                return;
            }

            jerseyStyleType.Set(command.Name, command.Abbreviation);

            await _jerseyStyleTypeRepository.Update(jerseyStyleType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
