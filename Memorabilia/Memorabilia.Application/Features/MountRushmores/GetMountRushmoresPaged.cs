namespace Memorabilia.Application.Features.MountRushmores;

[AuthorizeByPermission(Enum.Permission.MountRushmore)]
public record GetMountRushmoresPaged(PageInfo PageInfo)
    : IQuery<MountRushmoresModel>
{
    public class Handler(IMountRushmoreRepository mountRushmoreRepository, IApplicationStateService applicationStateService)
        : QueryHandler<GetMountRushmoresPaged, MountRushmoresModel>
    {
        protected override async Task<MountRushmoresModel> Handle(GetMountRushmoresPaged query)
        {
            PagedResult<Entity.MountRushmore> result
                = await mountRushmoreRepository.GetAll(applicationStateService.CurrentUser.Id, query.PageInfo);

            return new MountRushmoresModel(result.Data, result.PageInfo);
        }
    }
}
