using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyTypes
{
    public class GetJerseyTypes
    {
        public class Handler : QueryHandler<Query, JerseyTypesViewModel>
        {
            private readonly IJerseyTypeRepository _jerseyTypeRepository;

            public Handler(IJerseyTypeRepository jerseyTypeRepository)
            {
                _jerseyTypeRepository = jerseyTypeRepository;
            }

            protected override async Task<JerseyTypesViewModel> Handle(Query query)
            {
                return new JerseyTypesViewModel(await _jerseyTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<JerseyTypesViewModel> { }
    }
}
