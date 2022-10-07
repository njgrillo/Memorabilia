using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FigureTypes;

public class GetFigureTypes
{
    public class Handler : QueryHandler<Query, FigureTypesViewModel>
    {
        private readonly IDomainRepository<FigureType> _figureTypeRepository;

        public Handler(IDomainRepository<FigureType> figureTypeRepository)
        {
            _figureTypeRepository = figureTypeRepository;
        }

        protected override async Task<FigureTypesViewModel> Handle(Query query)
        {
            return new FigureTypesViewModel(await _figureTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<FigureTypesViewModel> { }
}
