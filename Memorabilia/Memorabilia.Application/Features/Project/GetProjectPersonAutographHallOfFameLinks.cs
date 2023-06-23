namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographHallOfFameLinks(int ItemTypeId,
                                                       int PersonId,
                                                       int SportLeagueLevelId,
                                                       int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographHallOfFameLinks, Entity.Autograph[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository,
                       IApplicationStateService applicationStateService)
        {
            _autographRepository = autographRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographHallOfFameLinks query)
            => await _autographRepository.GetAllHallOfFamers(query.ItemTypeId,
                                                             query.PersonId,
                                                             query.SportLeagueLevelId,
                                                             query.Year,
                                                             _applicationStateService.CurrentUser.Id);
    }
}
