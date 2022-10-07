using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public class SaveFigureSpecialtyType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            FigureSpecialtyType figureSpecialtyType;

            if (command.IsNew)
            {
                figureSpecialtyType = new FigureSpecialtyType(command.Name, command.Abbreviation);
                await _figureSpecialtyTypeRepository.Add(figureSpecialtyType);

                return;
            }

            figureSpecialtyType = await _figureSpecialtyTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _figureSpecialtyTypeRepository.Delete(figureSpecialtyType);

                return;
            }

            figureSpecialtyType.Set(command.Name, command.Abbreviation);

            await _figureSpecialtyTypeRepository.Update(figureSpecialtyType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
