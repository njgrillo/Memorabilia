namespace Memorabilia.Application.Features.MountRushmore;

public record GetMountRushmore(int Id) : IQuery<Entity.MountRushmore>
{
    public class Handler(IMountRushmoreRepository mountRushmoreRepository)
        : QueryHandler<GetMountRushmore, Entity.MountRushmore>
    {
        protected override async Task<Entity.MountRushmore> Handle(GetMountRushmore query)
            => await mountRushmoreRepository.Get(query.Id);
    }
}
