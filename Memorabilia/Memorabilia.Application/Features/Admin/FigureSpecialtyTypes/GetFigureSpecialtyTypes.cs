using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public record GetFigureSpecialtyTypes() : IQuery<FigureSpecialtyTypesViewModel>
{
    public class Handler : QueryHandler<GetFigureSpecialtyTypes, FigureSpecialtyTypesViewModel>
    {
        private readonly IDomainRepository<FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<FigureSpecialtyTypesViewModel> Handle(GetFigureSpecialtyTypes query)
        {
            return new FigureSpecialtyTypesViewModel(await _figureSpecialtyTypeRepository.GetAll());
        }
    }
}
