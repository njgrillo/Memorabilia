namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographCardLinks(int ItemTypeId,
                                                 int PersonId,
                                                 int BrandId,
                                                 int? TeamId,
                                                 int? Year)
     : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographCardLinks, Entity.Autograph[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository,
                       IApplicationStateService applicationStateService)
        {
            _autographRepository = autographRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographCardLinks query)
            => await _autographRepository.GetAllCards(query.ItemTypeId,
                                                      query.PersonId,
                                                      query.BrandId,
                                                      query.TeamId,
                                                      query.Year,
                                                      _applicationStateService.CurrentUser.Id);
    }
}
