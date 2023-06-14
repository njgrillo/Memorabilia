namespace Memorabilia.Application.Features.Project;

public record GetProjectPersonAutographLinks(Dictionary<string, object> Parameters)
     : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetProjectPersonAutographLinks, Entity.Autograph[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository, 
                       IApplicationStateService applicationStateService)
        {
            _autographRepository = autographRepository;
            _applicationStateService = applicationStateService;     
        }

        protected override async Task<Entity.Autograph[]> Handle(GetProjectPersonAutographLinks query)
            => await _autographRepository.GetAll(query.Parameters, _applicationStateService.CurrentUser.Id);
    }
}
