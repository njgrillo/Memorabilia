using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PriorityTypes
{
    public class GetPriorityTypes
    {
        public class Handler : QueryHandler<Query, PriorityTypesViewModel>
        {
            private readonly IPriorityTypeRepository _priorityTypeRepository;

            public Handler(IPriorityTypeRepository priorityTypeRepository)
            {
                _priorityTypeRepository = priorityTypeRepository;
            }

            protected override async Task<PriorityTypesViewModel> Handle(Query query)
            {
                return new PriorityTypesViewModel(await _priorityTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PriorityTypesViewModel> { }
    }
}
