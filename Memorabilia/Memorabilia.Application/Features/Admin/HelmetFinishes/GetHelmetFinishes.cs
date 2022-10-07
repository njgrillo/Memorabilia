using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public class GetHelmetFinishes
{
    public class Handler : QueryHandler<Query, HelmetFinishesViewModel>
    {
        private readonly IDomainRepository<HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task<HelmetFinishesViewModel> Handle(Query query)
        {
            return new HelmetFinishesViewModel(await _helmetFinishRepository.GetAll());
        }
    }

    public class Query : IQuery<HelmetFinishesViewModel> { }
}
