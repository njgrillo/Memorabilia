namespace Memorabilia.Application.Features.Project;

public record GetProjectMemorabiliaTeamLinksForHelmet(int itemTypeId,
                                                      int? teamId,
                                                      int? typeId,
                                                      int? sizeId,
                                                      int? finishId)
     : IQuery<Entity.Memorabilia[]>
{
    public class Handler : QueryHandler<GetProjectMemorabiliaTeamLinksForHelmet, Entity.Memorabilia[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository,
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Memorabilia[]> Handle(GetProjectMemorabiliaTeamLinksForHelmet query)
            => await _memorabiliaRepository.GetAllForHelmetProject(query.itemTypeId, 
                                                                   query.teamId,      
                                                                   query.typeId,
                                                                   query.sizeId,
                                                                   query.finishId,
                                                                   _applicationStateService.CurrentUser.Id);
    }
}
