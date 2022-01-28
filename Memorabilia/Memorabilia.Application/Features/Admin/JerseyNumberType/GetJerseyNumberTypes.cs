using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyNumberType
{
    public class GetJerseyNumberTypes
    {
        public class Handler : QueryHandler<Query, JerseyNumberTypesViewModel>
        {
            private readonly IJerseyNumberTypeRepository _jerseyNumberTypeRepository;

            public Handler(IJerseyNumberTypeRepository jerseyNumberTypeRepository)
            {
                _jerseyNumberTypeRepository = jerseyNumberTypeRepository;
            }

            protected override async Task<JerseyNumberTypesViewModel> Handle(Query query)
            {
                var jerseyNumberTypes = await _jerseyNumberTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new JerseyNumberTypesViewModel(jerseyNumberTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<JerseyNumberTypesViewModel>
        {
        }
    }
}
