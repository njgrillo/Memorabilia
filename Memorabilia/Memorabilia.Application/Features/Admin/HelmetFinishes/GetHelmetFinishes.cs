using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes
{
    public class GetHelmetFinishes
    {
        public class Handler : QueryHandler<Query, HelmetFinishesViewModel>
        {
            private readonly IHelmetFinishRepository _helmetFinishRepository;

            public Handler(IHelmetFinishRepository helmetFinishRepository)
            {
                _helmetFinishRepository = helmetFinishRepository;
            }

            protected override async Task<HelmetFinishesViewModel> Handle(Query query)
            {
                return new HelmetFinishesViewModel(await _helmetFinishRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<HelmetFinishesViewModel> { }
    }
}
