using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyLevelType
{
    public class GetJerseyLevelTypes
    {
        public class Handler : QueryHandler<Query, JerseyLevelTypesViewModel>
        {
            private readonly IJerseyLevelTypeRepository _jerseyLevelTypeRepository;

            public Handler(IJerseyLevelTypeRepository jerseyLevelTypeRepository)
            {
                _jerseyLevelTypeRepository = jerseyLevelTypeRepository;
            }

            protected override async Task<JerseyLevelTypesViewModel> Handle(Query query)
            {
                var jerseyLevelTypes = await _jerseyLevelTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new JerseyLevelTypesViewModel(jerseyLevelTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<JerseyLevelTypesViewModel>
        {
        }
    }
}
