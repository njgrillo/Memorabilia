using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetThroughTheMails(int[] ThroughTheMailIds = null) : IQuery<Entity.ThroughTheMail[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IThroughTheMailRepository throughTheMailRepository) 
        : QueryHandler<GetThroughTheMails, Entity.ThroughTheMail[]>
    {
        protected override async Task<Entity.ThroughTheMail[]> Handle(GetThroughTheMails query)
            => (await throughTheMailRepository.GetAll(applicationStateService.CurrentUser.Id, query.ThroughTheMailIds))
                   .OrderBy(throughTheMail => throughTheMail.SentDate)
                   .ToArray();
    }
}
