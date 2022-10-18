using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record SaveFigureSpecialtyType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveFigureSpecialtyType>
    {
        private readonly IDomainRepository<FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task Handle(SaveFigureSpecialtyType request)
        {
            FigureSpecialtyType figureSpecialtyType;

            if (request.ViewModel.IsNew)
            {
                figureSpecialtyType = new FigureSpecialtyType(request.ViewModel.Name, request.ViewModel.Abbreviation);
                await _figureSpecialtyTypeRepository.Add(figureSpecialtyType);

                return;
            }

            figureSpecialtyType = await _figureSpecialtyTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _figureSpecialtyTypeRepository.Delete(figureSpecialtyType);

                return;
            }

            figureSpecialtyType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _figureSpecialtyTypeRepository.Update(figureSpecialtyType);
        }
    }
}
