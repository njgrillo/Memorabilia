using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record GetLeaderType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetLeaderType, DomainModel>
    {
        private readonly IDomainRepository<LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetLeaderType query)
        {
            return new DomainModel(await _leaderTypeRepository.Get(query.Id));
        }
    }
}
