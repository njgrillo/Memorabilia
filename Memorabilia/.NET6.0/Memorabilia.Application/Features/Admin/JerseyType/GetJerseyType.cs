using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.JerseyType
{
    public class GetJerseyType
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IJerseyTypeRepository _jerseyTypeRepository;

            public Handler(IJerseyTypeRepository jerseyTypeRepository)
            {
                _jerseyTypeRepository = jerseyTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var jerseyType = await _jerseyTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(jerseyType);

                return viewModel;
            }
        }
    }
}
