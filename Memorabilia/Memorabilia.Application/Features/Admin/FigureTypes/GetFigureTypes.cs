using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public record GetFigureTypes() : IQuery<FigureTypesViewModel>
{
    public class Handler : QueryHandler<GetFigureTypes, FigureTypesViewModel>
    {
        private readonly IDomainRepository<FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task<FigureTypesViewModel> Handle(GetFigureTypes query)
        {
            return new FigureTypesViewModel(await _figureTypeRepository.GetAll());
        }
    }
}
