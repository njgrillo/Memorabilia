using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Color
{
    public class GetColor
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IColorRepository _colorRepository;

            public Handler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var color = await _colorRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(color);

                return viewModel;
            }
        }
    }
}
