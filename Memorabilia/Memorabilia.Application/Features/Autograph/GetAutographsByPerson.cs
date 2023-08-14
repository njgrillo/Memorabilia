namespace Memorabilia.Application.Features.Autograph;

public record GetAutographsByPerson(int PersonId)
    : IQuery<Entity.Autograph[]>
{
    public class Handler : QueryHandler<GetAutographsByPerson, Entity.Autograph[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;

        public Handler(IApplicationStateService applicationStateService,
            IAutographRepository autographRepository)
        {
            _applicationStateService = applicationStateService;
            _autographRepository = autographRepository;
        }

        protected override async Task<Entity.Autograph[]> Handle(GetAutographsByPerson query)
            => await _autographRepository.GetAllByPerson(query.PersonId, _applicationStateService.CurrentUser.Id);
    }
}
