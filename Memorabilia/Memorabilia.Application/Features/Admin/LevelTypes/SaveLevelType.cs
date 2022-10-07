using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public class SaveLevelType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            LevelType levelType;

            if (command.IsNew)
            {
                levelType = new LevelType(command.Name, command.Abbreviation);

                await _levelTypeRepository.Add(levelType);

                return;
            }

            levelType = await _levelTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _levelTypeRepository.Delete(levelType);

                return;
            }

            levelType.Set(command.Name, command.Abbreviation);

            await _levelTypeRepository.Update(levelType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
