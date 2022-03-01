using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetFinish
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
                var helmetFinishs = await _helmetFinishRepository.GetAll().ConfigureAwait(false);

                var viewModel = new HelmetFinishesViewModel(helmetFinishs);

                return viewModel;
            }
        }

        public class Query : IQuery<HelmetFinishesViewModel> { }
    }
}
