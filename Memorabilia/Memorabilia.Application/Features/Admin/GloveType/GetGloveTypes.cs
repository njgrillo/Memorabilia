using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GloveType
{
    public class GetGloveTypes
    {
        public class Handler : QueryHandler<Query, GloveTypesViewModel>
        {
            private readonly IGloveTypeRepository _gloveTypeRepository;

            public Handler(IGloveTypeRepository gloveTypeRepository)
            {
                _gloveTypeRepository = gloveTypeRepository;
            }

            protected override async Task<GloveTypesViewModel> Handle(Query query)
            {
                var gloveTypes = await _gloveTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new GloveTypesViewModel(gloveTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<GloveTypesViewModel> { }
    }
}
