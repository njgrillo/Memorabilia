namespace Memorabilia.Application.Features.Project;

public record GetProjectMemorabiliaTeamLinks(int itemTypeId,
                                             int? teamId,
                                             int? teamYear)
     : IQuery<Entity.Memorabilia[]>
{
    public class Handler : QueryHandler<GetProjectMemorabiliaTeamLinks, Entity.Memorabilia[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository, 
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Memorabilia[]> Handle(GetProjectMemorabiliaTeamLinks query)
            => await _memorabiliaRepository.GetAllForTeamProject(query.itemTypeId, 
                                                                 query.teamId,                               
                                                                 query.teamYear,
                                                                 _applicationStateService.CurrentUser.Id);
    }
}
