using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;

public class GetFigureSpecialtyTypes
{
    public class Handler : QueryHandler<Query, FigureSpecialtyTypesViewModel>
    {
        private readonly IDomainRepository<FigureSpecialtyType> _figureSpecialtyTypeRepository;

        public Handler(IDomainRepository<FigureSpecialtyType> figureSpecialtyTypeRepository)
        {
            _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
        }

        protected override async Task<FigureSpecialtyTypesViewModel> Handle(Query query)
        {
            return new FigureSpecialtyTypesViewModel(await _figureSpecialtyTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<FigureSpecialtyTypesViewModel> { }
}
