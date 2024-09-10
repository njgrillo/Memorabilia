namespace Memorabilia.Application.Features.DisplayCases;

[AuthorizeByPermission(Enum.Permission.DisplayCases)]
public record GetDisplayCasesPaged(PageInfo PageInfo)
    : IQuery<DisplayCasesModel>
{
    public class Handler(IDisplayCaseRepository displayCaseRepository, IApplicationStateService applicationStateService)
        : QueryHandler<GetDisplayCasesPaged, DisplayCasesModel>
    {
        protected override async Task<DisplayCasesModel> Handle(GetDisplayCasesPaged query)
        {
            PagedResult<Entity.DisplayCase> result
                = await displayCaseRepository.GetAll(applicationStateService.CurrentUser.Id, query.PageInfo);

            return new DisplayCasesModel(result.Data, result.PageInfo);
        }
    }
}
