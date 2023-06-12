namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public record GetSingleSeasonRecords(Constant.Sport Sport) 
    : IQuery<Entity.SingleSeasonRecord[]>
{
    public class Handler : QueryHandler<GetSingleSeasonRecords, Entity.SingleSeasonRecord[]>
    {
        private readonly ISingleSeasonRecordRepository _singleSeasonRecordRepository;

        public Handler(ISingleSeasonRecordRepository singleSeasonRecordRepository)
        {
            _singleSeasonRecordRepository = singleSeasonRecordRepository;
        }

        protected override async Task<Entity.SingleSeasonRecord[]> Handle(GetSingleSeasonRecords query)
            => (await _singleSeasonRecordRepository.GetAll(query.Sport.Id))
                    .ToArray();
    }
}
