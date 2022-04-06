using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FigureSpecialtyTypes
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
                return new DomainViewModel(await _figureSpecialtyTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
