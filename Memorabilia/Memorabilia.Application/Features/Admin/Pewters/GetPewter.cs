using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Pewters;

public class GetPewter
{
    public class Handler : QueryHandler<Query, PewterViewModel>
    {
        private readonly IDomainRepository<Pewter> _pewterRepository;

        public Handler(IDomainRepository<Pewter> pewterRepository)
        {
            _pewterRepository = pewterRepository;
        }

        protected override async Task<PewterViewModel> Handle(Query query)
        {
            return new PewterViewModel(await _pewterRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<PewterViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
