namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public record GetSingleSeasonRecords(Constant.Sport Sport) 
    : IQuery<Entity.SingleSeasonRecord[]>
{
    public class Handler(ISingleSeasonRecordRepository singleSeasonRecordRepository) 
        : QueryHandler<GetSingleSeasonRecords, Entity.SingleSeasonRecord[]>
    {
        protected override async Task<Entity.SingleSeasonRecord[]> Handle(GetSingleSeasonRecords query)
            => (await singleSeasonRecordRepository.GetAll(query.Sport.Id))
                    .ToArray();
    }
}
