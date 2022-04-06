using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes
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
                return new FigureSpecialtyTypesViewModel(await _figureSpecialtyTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<FigureSpecialtyTypesViewModel> { }
    }
}
