namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetThroughTheMails(int[] ThroughTheMailIds = null) : IQuery<Entity.ThroughTheMail[]>
{
    public class Handler : QueryHandler<GetThroughTheMails, Entity.ThroughTheMail[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IThroughTheMailRepository _throughTheMailRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IThroughTheMailRepository throughTheMailRepository)
        {
            _applicationStateService = applicationStateService;
            _throughTheMailRepository = throughTheMailRepository;            
        }

        protected override async Task<Entity.ThroughTheMail[]> Handle(GetThroughTheMails query)
            => (await _throughTheMailRepository.GetAll(_applicationStateService.CurrentUser.Id, query.ThroughTheMailIds))
                   .OrderBy(throughTheMail => throughTheMail.SentDate)
                   .ToArray();
    }
}
