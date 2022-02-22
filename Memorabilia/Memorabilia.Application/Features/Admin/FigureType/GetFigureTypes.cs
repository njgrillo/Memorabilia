using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureType
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
                var figureTypes = await _figureTypeRepository.GetAll().ConfigureAwait(false);

                return new FigureTypesViewModel(figureTypes);
            }
        }

        public class Query : IQuery<FigureTypesViewModel> { }
    }
}
