using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureType
{
    public class SaveFigureType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IFigureTypeRepository _figureTypeRepository;

            public Handler(IFigureTypeRepository figureTypeRepository)
            {
                _figureTypeRepository = figureTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.FigureType figureType;

                if (command.IsNew)
                {
                    figureType = new Domain.Entities.FigureType(command.Name, command.Abbreviation);
                    await _figureTypeRepository.Add(figureType).ConfigureAwait(false);

                    return;
                }

                figureType = await _figureTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _figureTypeRepository.Delete(figureType).ConfigureAwait(false);

                    return;
                }

                figureType.Set(command.Name, command.Abbreviation);

                await _figureTypeRepository.Update(figureType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
