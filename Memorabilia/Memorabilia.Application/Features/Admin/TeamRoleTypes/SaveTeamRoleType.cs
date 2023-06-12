namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

public record SaveTeamRoleType(DomainEditModel TeamRoleType) : ICommand
{
    public class Handler : CommandHandler<SaveTeamRoleType>
    {
        private readonly IDomainRepository<Entity.TeamRoleType> _teamRoleTypeRepository;

        public Handler(IDomainRepository<Entity.TeamRoleType> teamRoleTypeRepository)
        {
            _teamRoleTypeRepository = teamRoleTypeRepository;
        }

        protected override async Task Handle(SaveTeamRoleType request)
        {
            Entity.TeamRoleType teamRoleType;

            if (request.TeamRoleType.IsNew)
            {
                teamRoleType = new Entity.TeamRoleType(request.TeamRoleType.Name, 
                                                       request.TeamRoleType.Abbreviation);

                await _teamRoleTypeRepository.Add(teamRoleType);

                return;
            }

            teamRoleType = await _teamRoleTypeRepository.Get(request.TeamRoleType.Id);

            if (request.TeamRoleType.IsDeleted)
            {
                await _teamRoleTypeRepository.Delete(teamRoleType);

                return;
            }

            teamRoleType.Set(request.TeamRoleType.Name, 
                             request.TeamRoleType.Abbreviation);

            await _teamRoleTypeRepository.Update(teamRoleType);
        }
    }
}
