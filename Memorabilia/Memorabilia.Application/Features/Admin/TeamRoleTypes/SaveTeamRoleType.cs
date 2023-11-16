namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveTeamRoleType(DomainEditModel TeamRoleType) : ICommand
{
    public class Handler(IDomainRepository<Entity.TeamRoleType> teamRoleTypeRepository) 
        : CommandHandler<SaveTeamRoleType>
    {
        protected override async Task Handle(SaveTeamRoleType request)
        {
            Entity.TeamRoleType teamRoleType;

            if (request.TeamRoleType.IsNew)
            {
                teamRoleType = new Entity.TeamRoleType(request.TeamRoleType.Name, 
                                                       request.TeamRoleType.Abbreviation);

                await teamRoleTypeRepository.Add(teamRoleType);

                return;
            }

            teamRoleType = await teamRoleTypeRepository.Get(request.TeamRoleType.Id);

            if (request.TeamRoleType.IsDeleted)
            {
                await teamRoleTypeRepository.Delete(teamRoleType);

                return;
            }

            teamRoleType.Set(request.TeamRoleType.Name, 
                             request.TeamRoleType.Abbreviation);

            await teamRoleTypeRepository.Update(teamRoleType);
        }
    }
}
