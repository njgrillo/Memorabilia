namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments.FranchiseRecords;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetFranchiseRecordsPaged(PageInfo PageInfo, string filter = null)
    : IQuery<FranchiseRecordsViewModel>
{
    public class Handler(IFranchiseRepository franchiseRepository)
        : QueryHandler<GetFranchiseRecordsPaged, FranchiseRecordsViewModel>
    {
        protected override async Task<FranchiseRecordsViewModel> Handle(GetFranchiseRecordsPaged query)
        {
            PagedResult<Entity.Franchise> result
                = await franchiseRepository.GetAll(query.PageInfo, query.filter);

            return new FranchiseRecordsViewModel(result.Data, result.PageInfo);
        }
    }
}
