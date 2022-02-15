using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.LevelType
{
    public class SaveLevelType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly ILevelTypeRepository _levelTypeRepository;

            public Handler(ILevelTypeRepository levelTypeRepository)
            {
                _levelTypeRepository = levelTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.LevelType levelType;

                if (command.IsNew)
                {
                    levelType = new Domain.Entities.LevelType(command.Name, command.Abbreviation);
                    await _levelTypeRepository.Add(levelType).ConfigureAwait(false);

                    return;
                }

                levelType = await _levelTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _levelTypeRepository.Delete(levelType).ConfigureAwait(false);

                    return;
                }

                levelType.Set(command.Name, command.Abbreviation);

                await _levelTypeRepository.Update(levelType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
