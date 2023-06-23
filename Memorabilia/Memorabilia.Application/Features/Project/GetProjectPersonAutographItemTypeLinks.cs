namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographItemTypeLinks(int ItemTypeId,
                                                     int PersonId,
                                                     bool? MultiSigned)
     : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographItemTypeLinks, Entity.Autograph[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository,
                       IApplicationStateService applicationStateService)
        {
            _autographRepository = autographRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographItemTypeLinks query)
            => await _autographRepository.GetAllItemTypes(query.ItemTypeId,
                                                          query.PersonId,
                                                          query.MultiSigned,
                                                          _applicationStateService.CurrentUser.Id);
    }
}
