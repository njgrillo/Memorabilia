namespace Memorabilia.Application.Features.MountRushmore;

public record GetMountRushmores()
    : IQuery<Entity.MountRushmore[]>
{
    public class Handler(IMountRushmoreRepository mountRushmoreRepository, IApplicationStateService applicationStateService)
        : QueryHandler<GetMountRushmores, Entity.MountRushmore[]>
    {
        protected override async Task<Entity.MountRushmore[]> Handle(GetMountRushmores query)
            => await mountRushmoreRepository.GetAll(applicationStateService.CurrentUser.Id);
    }
}
