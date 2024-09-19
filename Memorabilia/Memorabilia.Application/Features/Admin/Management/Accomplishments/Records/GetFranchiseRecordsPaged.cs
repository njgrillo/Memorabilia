﻿namespace Memorabilia.Application.Features.Admin.Management.Accomplishments.Records;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetFranchiseRecordsPaged(PageInfo PageInfo)
    : IQuery<FranchiseRecordsViewModel>
{
    public class Handler(IFranchiseRepository franchiseRepository)
        : QueryHandler<GetFranchiseRecordsPaged, FranchiseRecordsViewModel>
    {
        protected override async Task<FranchiseRecordsViewModel> Handle(GetFranchiseRecordsPaged query)
        {
            PagedResult<Entity.Franchise> result
                = await franchiseRepository.GetAll(query.PageInfo);

            return new FranchiseRecordsViewModel(result.Data, result.PageInfo);
        }
    }
}
