using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public record SaveFigureType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveFigureType>
    {
        private readonly IDomainRepository<FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task Handle(SaveFigureType request)
        {
            FigureType figureType;

            if (request.ViewModel.IsNew)
            {
                figureType = new FigureType(request.ViewModel.Name, request.ViewModel.Abbreviation);
                await _figureTypeRepository.Add(figureType);

                return;
            }

            figureType = await _figureTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _figureTypeRepository.Delete(figureType);

                return;
            }

            figureType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _figureTypeRepository.Update(figureType);
        }
    }
}
