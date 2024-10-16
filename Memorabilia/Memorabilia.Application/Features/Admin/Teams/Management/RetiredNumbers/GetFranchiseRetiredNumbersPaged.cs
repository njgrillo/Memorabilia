namespace Memorabilia.Application.Features.Admin.Teams.Management.RetiredNumbers;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetFranchiseRetiredNumbersPaged(PageInfo PageInfo, string Filter = null)
    : IQuery<FranchiseRetiredNumbersViewModel>
{
    public class Handler(IFranchiseRepository franchiseRepository)
        : QueryHandler<GetFranchiseRetiredNumbersPaged, FranchiseRetiredNumbersViewModel>
    {
        protected override async Task<FranchiseRetiredNumbersViewModel> Handle(GetFranchiseRetiredNumbersPaged query)
        {
            PagedResult<Entity.Franchise> result
                = await franchiseRepository.GetAll(query.PageInfo, query.Filter);

            return new FranchiseRetiredNumbersViewModel(result.Data, result.PageInfo);
        }
    }
}
