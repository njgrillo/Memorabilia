using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyType
{
    public class GetFigureSpecialtyType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IFigureSpecialtyTypeRepository _figureSpecialtyTypeRepository;

            public Handler(IFigureSpecialtyTypeRepository figureSpecialtyTypeRepository)
            {
                _figureSpecialtyTypeRepository = figureSpecialtyTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var figureSpecialtyType = await _figureSpecialtyTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(figureSpecialtyType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
