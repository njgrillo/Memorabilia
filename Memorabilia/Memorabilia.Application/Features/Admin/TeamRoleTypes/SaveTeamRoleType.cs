using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record SaveTeamRoleType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveTeamRoleType>
    {
        private readonly IDomainRepository<TeamRoleType> _teamRoleTypeRepository;

        public Handler(IDomainRepository<TeamRoleType> teamRoleTypeRepository)
        {
            _teamRoleTypeRepository = teamRoleTypeRepository;
        }

        protected override async Task Handle(SaveTeamRoleType request)
        {
            TeamRoleType teamRoleType;

            if (request.ViewModel.IsNew)
            {
                teamRoleType = new TeamRoleType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _teamRoleTypeRepository.Add(teamRoleType);

                return;
            }

            teamRoleType = await _teamRoleTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _teamRoleTypeRepository.Delete(teamRoleType);

                return;
            }

            teamRoleType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _teamRoleTypeRepository.Update(teamRoleType);
        }
    }
}
