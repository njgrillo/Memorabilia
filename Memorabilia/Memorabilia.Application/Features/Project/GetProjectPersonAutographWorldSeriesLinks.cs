namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographWorldSeriesLinks(int ItemTypeId,
                                                        int PersonId,
                                                        int TeamId,
                                                        int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographWorldSeriesLinks, Entity.Autograph[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository,
                       IApplicationStateService applicationStateService)
        {
            _autographRepository = autographRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographWorldSeriesLinks query)
            => await _autographRepository.GetAllWorldSeries(query.ItemTypeId,
                                                            query.PersonId,
                                                            query.TeamId,
                                                            query.Year,
                                                            _applicationStateService.CurrentUser.Id);
    }
}
