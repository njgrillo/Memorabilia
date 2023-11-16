using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographTeamLinks(int ItemTypeId,
                                                 int PersonId,
                                                 int TeamId,
                                                 int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler(IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectPersonAutographTeamLinks, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographTeamLinks query)
            => await autographRepository.GetAllTeams(query.ItemTypeId,
                                                     query.PersonId,
                                                     query.TeamId,
                                                     query.Year,
                                                     applicationStateService.CurrentUser.Id);
    }
}
