using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public class GetHelmetFinish
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _helmetFinishRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
