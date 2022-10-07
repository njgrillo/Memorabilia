using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports;

public class GetSports
{
    public class Handler : QueryHandler<Query, SportsViewModel>
    {
        private readonly IDomainRepository<Sport> _sportRepository;

        public Handler(IDomainRepository<Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task<SportsViewModel> Handle(Query query)
        {
            return new SportsViewModel(await _sportRepository.GetAll());
        }
    }

    public class Query : IQuery<SportsViewModel> { }
}
