using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes
{
    public class GetJerseyStyleTypes
    {
        public class Handler : QueryHandler<Query, JerseyStyleTypesViewModel>
        {
            private readonly IJerseyStyleTypeRepository _jerseyStyleTypeRepository;

            public Handler(IJerseyStyleTypeRepository jerseyStyleTypeRepository)
            {
                _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
            }

            protected override async Task<JerseyStyleTypesViewModel> Handle(Query query)
            {
                return new JerseyStyleTypesViewModel(await _jerseyStyleTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<JerseyStyleTypesViewModel> { }
    }
}
