using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record GetTeamRoleType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetTeamRoleType, DomainModel>
    {
        private readonly IDomainRepository<TeamRoleType> _TeamRoleTypeRepository;

        public Handler(IDomainRepository<TeamRoleType> TeamRoleTypeRepository)
        {
            _TeamRoleTypeRepository = TeamRoleTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetTeamRoleType query)
        {
            return new DomainModel(await _TeamRoleTypeRepository.Get(query.Id));
        }
    }
}
