using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Project;

public record GetProjectMemorabiliaTeamLinksForHelmet(int ItemTypeId,
                                                      int? TeamId,
                                                      int? TypeId,
                                                      int? SizeId,
                                                      int? FinishId)
     : IQuery<Entity.Memorabilia[]>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectMemorabiliaTeamLinksForHelmet, Entity.Memorabilia[]>
    {
        protected override async Task<Entity.Memorabilia[]> Handle(GetProjectMemorabiliaTeamLinksForHelmet query)
            => await memorabiliaRepository.GetAllForHelmetProject(query.ItemTypeId, 
                                                                  query.TeamId,      
                                                                  query.TypeId,
                                                                  query.SizeId,
                                                                  query.FinishId,
                                                                  applicationStateService.CurrentUser.Id);
    }
}
