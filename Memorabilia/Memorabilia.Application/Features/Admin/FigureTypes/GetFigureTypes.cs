namespace Memorabilia.Application.Features.Admin.FigureTypes
{
    public class GetFigureTypes
    {
        public class Handler : QueryHandler<Query, FigureTypesViewModel>
        {
            private readonly IFigureTypeRepository _figureTypeRepository;

            public Handler(IFigureTypeRepository figureTypeRepository)
            {
                _figureTypeRepository = figureTypeRepository;
            }

            protected override async Task<FigureTypesViewModel> Handle(Query query)
            {
                return new FigureTypesViewModel(await _figureTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<FigureTypesViewModel> { }
    }
}
