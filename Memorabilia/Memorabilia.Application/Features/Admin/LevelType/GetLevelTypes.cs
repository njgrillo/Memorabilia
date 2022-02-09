using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.LevelType
{
    public class GetLevelTypes
    {
        public class Handler : QueryHandler<Query, LevelTypesViewModel>
        {
            private readonly ILevelTypeRepository _levelTypeRepository;

            public Handler(ILevelTypeRepository levelTypeRepository)
            {
                _levelTypeRepository = levelTypeRepository;
            }

            protected override async Task<LevelTypesViewModel> Handle(Query query)
            {
                var levelTypes = await _levelTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new LevelTypesViewModel(levelTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<LevelTypesViewModel>
        {
        }
    }
}
