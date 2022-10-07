using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public class SaveFigureType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            FigureType figureType;

            if (command.IsNew)
            {
                figureType = new FigureType(command.Name, command.Abbreviation);
                await _figureTypeRepository.Add(figureType);

                return;
            }

            figureType = await _figureTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _figureTypeRepository.Delete(figureType);

                return;
            }

            figureType.Set(command.Name, command.Abbreviation);

            await _figureTypeRepository.Update(figureType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
