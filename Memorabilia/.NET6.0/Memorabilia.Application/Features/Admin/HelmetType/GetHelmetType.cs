using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.HelmetType
{
    public class GetHelmetType
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IHelmetTypeRepository _helmetTypeRepository;

            public Handler(IHelmetTypeRepository helmetTypeRepository)
            {
                _helmetTypeRepository = helmetTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var helmetType = await _helmetTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(helmetType);

                return viewModel;
            }
        }
    }
}
