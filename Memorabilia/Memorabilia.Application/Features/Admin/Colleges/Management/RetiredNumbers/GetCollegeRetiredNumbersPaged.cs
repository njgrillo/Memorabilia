namespace Memorabilia.Application.Features.Admin.Colleges.Management.RetiredNumbers;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetCollegeRetiredNumbersPaged(PageInfo PageInfo, string Filter = null)
    : IQuery<CollegeRetiredNumbersViewModel>
{
    public class Handler(ICollegeRepository CollegeRepository)
        : QueryHandler<GetCollegeRetiredNumbersPaged, CollegeRetiredNumbersViewModel>
    {
        protected override async Task<CollegeRetiredNumbersViewModel> Handle(GetCollegeRetiredNumbersPaged query)
        {
            PagedResult<Entity.College> result
                = await CollegeRepository.GetAll(query.PageInfo, query.Filter);

            return new CollegeRetiredNumbersViewModel(result.Data, result.PageInfo);
        }
    }
}
