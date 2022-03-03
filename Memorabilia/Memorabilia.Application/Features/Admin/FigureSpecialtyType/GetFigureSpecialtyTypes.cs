using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyType
{
    public class GetFigureSpecialtyTypes
    {
        public class Handler : QueryHandler<Query, FigureSpecialtyTypesViewModel>
        {
            private readonly IFigureSpecialtyTypeRepository _figureSpecialtyTypeRepository;

            public Handler(IFigureSpecialtyTypeRepository figureSpecialtyTypeRepository)
            {
                _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
            }

            protected override async Task<FigureSpecialtyTypesViewModel> Handle(Query query)
            {
                var figureSpecialtyTypes = await _figureSpecialtyTypeRepository.GetAll().ConfigureAwait(false);

                return new FigureSpecialtyTypesViewModel(figureSpecialtyTypes);
            }
        }

        public class Query : IQuery<FigureSpecialtyTypesViewModel> { }
    }
}
