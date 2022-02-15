using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Color
{
    public class GetColor
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IColorRepository _colorRepository;

            public Handler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var color = await _colorRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(color);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
