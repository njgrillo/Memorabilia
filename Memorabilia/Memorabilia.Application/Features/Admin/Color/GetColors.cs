using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Color
{
    public class GetColors
    {
        public class Handler : QueryHandler<Query, ColorsViewModel>
        {
            private readonly IColorRepository _colorRepository;

            public Handler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            protected override async Task<ColorsViewModel> Handle(Query query)
            {
                var colors = await _colorRepository.GetAll().ConfigureAwait(false);

                var viewModel = new ColorsViewModel(colors);

                return viewModel;
            }
        }

        public class Query : IQuery<ColorsViewModel> { }
    }
}
