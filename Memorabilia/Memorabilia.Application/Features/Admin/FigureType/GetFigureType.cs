using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureType
{
    public class GetFigureType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IFigureTypeRepository _figureTypeRepository;

            public Handler(IFigureTypeRepository figureTypeRepository)
            {
                _figureTypeRepository = figureTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var figureType = await _figureTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(figureType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
