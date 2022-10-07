using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports;

public class GetSport
{
    public class Handler : QueryHandler<Query, SportViewModel>
    {
        private readonly IDomainRepository<Sport> _sportRepository;

        public Handler(IDomainRepository<Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task<SportViewModel> Handle(Query query)
        {
            return new SportViewModel(await _sportRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<SportViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
