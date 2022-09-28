using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes
{
    public class SaveFigureSpecialtyType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IFigureSpecialtyTypeRepository _figureSpecialtyTypeRepository;

            public Handler(IFigureSpecialtyTypeRepository figureSpecialtyTypeRepository)
            {
                _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                FigureSpecialtyType figureSpecialtyType;

                if (command.IsNew)
                {
                    figureSpecialtyType = new FigureSpecialtyType(command.Name, command.Abbreviation);
                    await _figureSpecialtyTypeRepository.Add(figureSpecialtyType).ConfigureAwait(false);

                    return;
                }

                figureSpecialtyType = await _figureSpecialtyTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _figureSpecialtyTypeRepository.Delete(figureSpecialtyType).ConfigureAwait(false);

                    return;
                }

                figureSpecialtyType.Set(command.Name, command.Abbreviation);

                await _figureSpecialtyTypeRepository.Update(figureSpecialtyType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
