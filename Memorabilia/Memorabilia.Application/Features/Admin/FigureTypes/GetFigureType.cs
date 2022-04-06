using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureTypes
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
                return new DomainViewModel(await _figureTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
