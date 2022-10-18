using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record GetLeaderType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetLeaderType, DomainViewModel>
    {
        private readonly IDomainRepository<LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetLeaderType query)
        {
            return new DomainViewModel(await _leaderTypeRepository.Get(query.Id));
        }
    }
}
