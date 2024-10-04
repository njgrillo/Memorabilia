namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonFranchiseRecords;

public record GetSingleSeasonFranchiseRecords(Constant.Franchise Franchise)
    : IQuery<Entity.SingleSeasonFranchiseRecord[]>
{
    public class Handler(ISingleSeasonFranchiseRecordRepository singleSeasonFranchiseRecordRepository)
        : QueryHandler<GetSingleSeasonFranchiseRecords, Entity.SingleSeasonFranchiseRecord[]>
    {
        protected override async Task<Entity.SingleSeasonFranchiseRecord[]> Handle(GetSingleSeasonFranchiseRecords query)
            => (await singleSeasonFranchiseRecordRepository.GetAllByFranchise(query.Franchise.Id))
                    .ToArray();
    }
}
