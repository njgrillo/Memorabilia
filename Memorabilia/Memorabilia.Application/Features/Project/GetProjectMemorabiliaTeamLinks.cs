namespace Memorabilia.Application.Features.Project;

public record GetProjectMemorabiliaTeamLinks(int ItemTypeId,
                                             int? TeamId,
                                             int? TeamYear)
     : IQuery<Entity.Memorabilia[]>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjectMemorabiliaTeamLinks, Entity.Memorabilia[]>
    {
        protected override async Task<Entity.Memorabilia[]> Handle(GetProjectMemorabiliaTeamLinks query)
            => await memorabiliaRepository.GetAllForTeamProject(query.ItemTypeId, 
                                                                query.TeamId,                               
                                                                query.TeamYear,
                                                                applicationStateService.CurrentUser.Id);
    }
}
