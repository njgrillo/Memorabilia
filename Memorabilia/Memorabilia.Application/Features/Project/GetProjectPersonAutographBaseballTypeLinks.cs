namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographBaseballTypeLinks(int ItemTypeId,
                                                         int PersonId,
                                                         int BaseballTypeId,
                                                         int? TeamId,
                                                         int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographBaseballTypeLinks, Entity.Autograph[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository,
                       IApplicationStateService applicationStateService)
        {
            _autographRepository = autographRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographBaseballTypeLinks query)
            => await _autographRepository.GetAllBaseballTypes(query.ItemTypeId,
                                                              query.PersonId,
                                                              query.BaseballTypeId,
                                                              query.TeamId,
                                                              query.Year, 
                                                              _applicationStateService.CurrentUser.Id);
    }
}
