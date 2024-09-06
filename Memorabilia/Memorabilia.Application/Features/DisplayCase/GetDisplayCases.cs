namespace Memorabilia.Application.Features.DisplayCase;

public record GetDisplayCases()
    : IQuery<Entity.DisplayCase[]>
{
    public class Handler(IDisplayCaseRepository displayCaseRepository, IApplicationStateService applicationStateService)
        : QueryHandler<GetDisplayCases, Entity.DisplayCase[]>
    {
        protected override async Task<Entity.DisplayCase[]> Handle(GetDisplayCases query)
            => await displayCaseRepository.GetAll(applicationStateService.CurrentUser.Id);
    }
}
