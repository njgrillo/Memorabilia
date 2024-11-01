namespace Memorabilia.Application.Features.MountRushmores;

[AuthorizeByPermission(Enum.Permission.MountRushmore)]
public record GetMountRushmoresPaged(PageInfo PageInfo, string Filter = null)
    : IQuery<MountRushmoresModel>
{
    public class Handler(IMountRushmoreRepository mountRushmoreRepository, IApplicationStateService applicationStateService)
        : QueryHandler<GetMountRushmoresPaged, MountRushmoresModel>
    {
        protected override async Task<MountRushmoresModel> Handle(GetMountRushmoresPaged query)
        {
            PagedResult<Entity.MountRushmore> result
                = await mountRushmoreRepository.GetAll(
                    applicationStateService.CurrentUser.Id, 
                    query.PageInfo,
                    query.Filter
                    );

            return new MountRushmoresModel(result.Data, result.PageInfo);
        }
    }
}
