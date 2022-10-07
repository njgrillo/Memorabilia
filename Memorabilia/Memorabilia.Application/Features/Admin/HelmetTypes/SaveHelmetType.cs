using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public class SaveHelmetType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            HelmetType helmetType;

            if (command.IsNew)
            {
                helmetType = new HelmetType(command.Name, command.Abbreviation);
                await _helmetTypeRepository.Add(helmetType);

                return;
            }

            helmetType = await _helmetTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _helmetTypeRepository.Delete(helmetType);

                return;
            }

            helmetType.Set(command.Name, command.Abbreviation);

            await _helmetTypeRepository.Update(helmetType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
